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
    private Text _LevelText;
    [SerializeField]
    private Text _timerText;
    [SerializeField]
    private Button _nextLevelButton;
    [SerializeField]
    private Button _restartLevelButton;

    // Start is called before the first frame update
    void Start()
    {
        _winText.gameObject.SetActive(false);
        _loseText.gameObject.SetActive(false);
        _nextLevelButton.gameObject.SetActive(false);
        _restartLevelButton.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
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
        _LevelText.text = "Level: " + currentLevel.ToString();
    }
}
