using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private const int titleMenu = 0;
    private const int mainGame = 1;
    private const int settingsMenu = 2;

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(titleMenu);
    }

    public void LoadMainGame()
    {
        SceneManager.LoadScene(mainGame);
    }

    public void LoadSettingsMenu()
    {
        SceneManager.LoadScene(settingsMenu);
    }


}
