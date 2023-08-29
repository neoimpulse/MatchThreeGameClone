using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float _startingTime = 60f;

    [SerializeField]
    public int _currentLevel;

    [SerializeField]
    private UIManager _UIManager;

    [SerializeField]
    private ShapesManager _shapesManager;

    [SerializeField]
    private MainMenu _mainMenu;

    private float _currentTime = 0;

    void Start()
    {
        _currentTime = _startingTime;

        Load();

        if (_currentLevel == 0)
        {
            _currentLevel = 1;
            _currentTime = _startingTime;
            _UIManager.LevelText(_currentLevel);
        }
    }

    void Update()
    {
        CountdownTimer();

        if (Input.GetKeyDown(KeyCode.P))
        {
            print(_shapesManager.score);
            print(_currentLevel);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }

    private void CountdownTimer()
    {
        _currentTime -= 1 * Time.deltaTime;
        _UIManager.CountdownTimerText(_currentTime);

        if (_currentTime <= 0)
        {
            _currentTime = 0;
            LoseState();
        }
    }

    private void LoseState()
    {
        _UIManager.PlayerLoseSequence();
        Time.timeScale = 0;
    }

    public void WinState()
    {        
        _UIManager.PlayerWinsSequence();
        Time.timeScale = 0;
    }
    private void LevelUpdate()
    {
        Time.timeScale = 1;
        _currentTime = _startingTime;
        _shapesManager.InitializeTypesOnPrefabShapesAndBonuses();
        _shapesManager.InitializeCandyAndSpawnPositions();
        _shapesManager.StartCheckForPotentialMatches();
        _shapesManager.InitializeVariables();
    }

    private void NextLevel()
    {
        _currentLevel += 1;
        _UIManager.LevelText(_currentLevel);
        _UIManager.NextLevelUIReset();
        LevelUpdate();
    }

    private void RestartLevel()
    {
        _UIManager.RestartLevelUIReset();
        LevelUpdate();
    }

    private void Save()
    {
        PlayerPrefs.SetInt("savedLevel", _currentLevel);
        PlayerPrefs.SetFloat("savedTime", _currentTime);
        PlayerPrefs.SetInt("savedScore", _shapesManager.score);
    }

    private void Load()
    {
        _currentLevel = PlayerPrefs.GetInt("savedLevel");
        _currentTime = PlayerPrefs.GetFloat("savedTime");
        _shapesManager.score = PlayerPrefs.GetInt("savedScore");
        _UIManager.LevelText(_currentLevel);
        _shapesManager.ShowScore();
    }

    public void ExitWithSave()
    {
        Save();
        Time.timeScale = 1;
        _mainMenu.LoadMainMenu();
    }

    public void ExitWithoutSave()
    {
        Time.timeScale = 1;
        _mainMenu.LoadMainMenu();
    }
}
