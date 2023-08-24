using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float _startingTime = 60f;

    [SerializeField]
    private int _currentLevel = 1;

    [SerializeField]
    private UIManager _UIManager;

    [SerializeField]
    private ShapesManager _shapesManager;

    private float _currentTime = 0;


    void Start()
    {
        _currentTime = _startingTime;
    }

    void Update()
    {
        CountdownTimer();
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
}
