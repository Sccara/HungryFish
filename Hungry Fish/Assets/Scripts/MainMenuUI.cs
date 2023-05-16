using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void ScoreWindow()
    {
        // Load score window here
    }

    public void Exit()
    {
        Application.Quit();
    }
}
