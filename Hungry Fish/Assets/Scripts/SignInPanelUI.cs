using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignInPanelUI : MonoBehaviour
{
    [SerializeField] private GameObject registrationPanel;

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        registrationPanel.SetActive(true);
    }
}
