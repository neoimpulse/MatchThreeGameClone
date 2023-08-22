using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public enum GameScenes
    {
        MainMenu, //0
        mainGame, //1
        SettingsMenu, //2
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene((int)GameScenes.MainMenu);
    }

    public void LoadMainGame()
    {
        SceneManager.LoadScene((int)GameScenes.mainGame);
    }

    public void LoadSettingsMenu()
    {
        SceneManager.LoadScene((int)GameScenes.SettingsMenu);
    }


}
