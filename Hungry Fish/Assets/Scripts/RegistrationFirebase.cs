using Firebase.Auth;
using Firebase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class RegistrationFirebase : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputFieldName, inputFieldEmail, inputFieldPassword;

    public void RegisterButton()
    {
        StartCoroutine(RegisterPlayer(inputFieldName.text, inputFieldEmail.text, inputFieldPassword.text));
    }


    private IEnumerator RegisterPlayer(string name, string email, string password)
    {
        var registerTask = FirebaseConnection.AuthorizationPlayer.CreateUserWithEmailAndPasswordAsync(email, password);
        yield return new WaitUntil(predicate: () => registerTask.IsCompleted);

        if (registerTask.Exception != null)
        {
            Debug.Log("Register Error!");
        }
        else
        {
            FirebaseConnection.User = registerTask.Result.User;

            if (FirebaseConnection.User != null)
            {
                UserProfile profile = new UserProfile { DisplayName = name };

                var profileTask = FirebaseConnection.User.UpdateUserProfileAsync(profile);
                yield return new WaitUntil(predicate: () => profileTask.IsCompleted);

                if (profileTask.Exception != null)
                {
                    Debug.Log("Error!");
                }
                else
                {
                    //PlayerPrefs.SetString("email", email);
                    //PlayerPrefs.SetString("password", password);

                    // Load Menu scene
                    SceneManager.LoadScene("MainMenu");
                }
            }
        }
    }


}