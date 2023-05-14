using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Firebase;

public class AuthorizationFirebase : MonoBehaviour
{
    [SerializeField] private InputField inputFieldEmail, inputFieldPassword;


    private void Start()
    {
        if (PlayerPrefs.HasKey("email") && PlayerPrefs.HasKey("password"))
        {
            inputFieldEmail.text = PlayerPrefs.GetString("email");
            inputFieldPassword.text = PlayerPrefs.GetString("password");
            Invoke("LoginButton", 1f);
        }

    }

    public void LoginButton()
    {
        StartCoroutine(SignIn(inputFieldEmail.text, inputFieldPassword.text));
    }

    private IEnumerator SignIn(string email, string password)
    {
        var loginTask = FirebaseConnection.AuthorizationPlayer.SignInWithEmailAndPasswordAsync(email, password);
        yield return new WaitUntil(predicate: () => loginTask.IsCompleted);

        if (loginTask.Exception != null)
        {
            Debug.Log("Authentication error!");
        }
        else
        {
            //PlayerPrefs.SetString("email", email);
            //PlayerPrefs.SetString("password", password);
            FirebaseConnection.User = loginTask.Result.User;
            
            // Load menu scene
        }
    }
}
