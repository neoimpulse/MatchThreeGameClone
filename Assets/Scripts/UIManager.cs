using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _winText;

    [SerializeField]
    private Text _loseText;

    [SerializeField]
    private Text _levelText;

    [SerializeField]
    private Text _timerText;

    [SerializeField]
    private Button _nextLevelButton;

    [SerializeField]
    private Button _restartLevelButton;

    [SerializeField]
    private Button _restartButton;

    [SerializeField]
    private Button _premadeLevelButton;

    [SerializeField]
    private Image _optionsMenuBackground;

    [SerializeField]
    private ShapesManager _shapesManager;

    private bool _isOptionsMenuOpen = false;

    void Start()
    {
        _winText.gameObject.SetActive(false);
        _loseText.gameObject.SetActive(false);
        _nextLevelButton.gameObject.SetActive(false);
        _restartLevelButton.gameObject.SetActive(false);
        _restartButton.gameObject.SetActive(false);
        _premadeLevelButton.gameObject.SetActive(false);
        _optionsMenuBackground.gameObject.SetActive(false);
    }

    void Update()
    {

    }

    public void PlayerWinsSequence()
    {
        _winText.gameObject.SetActive(true);
        _nextLevelButton.gameObject.SetActive(true);
    }

    public void PlayerLoseSequence()
    {
        _loseText.gameObject.SetActive(true);
        _restartLevelButton.gameObject.SetActive(true);
    }

    public void NextLevelUIReset()
    {
        _winText.gameObject.SetActive(false);
        _nextLevelButton.gameObject.SetActive(false);
    }

    public void RestartLevelUIReset()
    {
        _loseText.gameObject.SetActive(false);
        _restartLevelButton.gameObject.SetActive(false);
    }

    public void CountdownTimerText(float currentTime)
    {
        _timerText.text = "Time Remaining: " + currentTime.ToString("0");
    }

    public void LevelText(int currentLevel)
    {
        _levelText.text = "Level: " + currentLevel.ToString();
    }

    public void OptionsMenuButton()
    {
        if (_isOptionsMenuOpen == false)
        {
            OpenOptionsMenu();
        }
        else if (_isOptionsMenuOpen == true)
        {
            CloseOptionsMenu();
        }
    }

    private void OpenOptionsMenu()
    {
        _restartButton.gameObject.SetActive(true);
        _premadeLevelButton.gameObject.SetActive(true);
        _optionsMenuBackground.gameObject.SetActive(true);
        _isOptionsMenuOpen = true;
        Time.timeScale = 0;
    }

    private void CloseOptionsMenu()
    {
        _restartButton.gameObject.SetActive(false);
        _premadeLevelButton.gameObject.SetActive(false);
        _optionsMenuBackground.gameObject.SetActive(false);
        _isOptionsMenuOpen = false;
        Time.timeScale = 1;
    }

    public void RestartButton()
    {
        CloseOptionsMenu();
        _shapesManager.InitializeCandyAndSpawnPositions();
    }

    public void PremadeLevelButton()
    {
        CloseOptionsMenu();        
        _shapesManager.InitializeCandyAndSpawnPositionsFromPremadeLevel();
    }
}
