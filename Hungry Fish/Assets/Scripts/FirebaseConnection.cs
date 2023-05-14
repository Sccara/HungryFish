using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using Firebase;

public class FirebaseConnection : MonoBehaviour
{
    public static FirebaseAuth AuthorizationPlayer;
    public static FirebaseUser User;

    //[SerializeField] private ErrorManager errorManager;

    private void Awake()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            DependencyStatus dependencyStatus = task.Result;

            if(dependencyStatus == DependencyStatus.Available)
            {
                AuthorizationPlayer = FirebaseAuth.DefaultInstance;
            }
            else
            {
                Debug.Log("Firebase connection error: " + dependencyStatus);
            }
        });
    }
}
