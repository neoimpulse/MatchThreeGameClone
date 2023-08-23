using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float _currentTime = 0;
    [SerializeField]
    private float startingTime = 60f;
    [SerializeField]
    private int currentLevel = 1;

    private UIManager _UIManager;
    private ShapesManager _shapesManager;

    // Start is called before the first frame update
    void Start()
    {
        _UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _shapesManager = GameObject.Find("ShapesManager").GetComponent<ShapesManager>();
        _currentTime = startingTime;

    }

    // Update is called once per frame
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


    public void LoseState()
    {
        _UIManager.PlayerLoseSequence();
        Time.timeScale = 0;
    }

    public void WinState()
    {        
        _UIManager.PlayerWinsSequence();
        Time.timeScale = 0;
    }

    public void NextLevel()
    {
        Time.timeScale = 1;
        currentLevel += 1;
        _UIManager.LevelText(currentLevel);
        _currentTime = startingTime;
        _UIManager.NextLevelUIReset();
        _shapesManager.InitializeTypesOnPrefabShapesAndBonuses();
        _shapesManager.InitializeCandyAndSpawnPositions();
        _shapesManager.StartCheckForPotentialMatches();
        _shapesManager.InitializeVariables();
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        _currentTime = startingTime;
        _UIManager.RestartLevelUIReset();
        _shapesManager.InitializeTypesOnPrefabShapesAndBonuses();
        _shapesManager.InitializeCandyAndSpawnPositions();
        _shapesManager.StartCheckForPotentialMatches();
        _shapesManager.InitializeVariables();
    }
}
