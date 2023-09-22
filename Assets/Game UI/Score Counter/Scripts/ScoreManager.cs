using System.Globalization;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text timeTextRetryMenu;
    [SerializeField] private TMP_Text scoreCounterTextRetryMenu;
    [SerializeField] private TMP_Text coinTextRetryMenu;
    [SerializeField] private GameObject retryMenu;
    
    private float _currentScore;
    private float _time;
    private float _coins;
    
    public void DisplayInRetryMenu(float time, float coins, float score)
    {
        retryMenu.SetActive(true);
        
        _currentScore = score;
        _time = time;
        _coins = coins;
        
        timeTextRetryMenu.text = "time: " + time;
        coinTextRetryMenu.text = "coins: " + coins;
        scoreCounterTextRetryMenu.text = score.ToString(CultureInfo.InvariantCulture);
        
        UpdateHighScore();
    }

    private void UpdateHighScore()
    {
        if (_currentScore > PlayerPrefs.GetFloat("HIGHSCORE"))
            PlayerPrefs.SetFloat("HIGHSCORE", _currentScore);
        if (_time > PlayerPrefs.GetFloat("TIME"))
            PlayerPrefs.SetFloat("TIME", _time);
        if (_coins > PlayerPrefs.GetFloat("COINS"))
            PlayerPrefs.SetFloat("COINS", _coins);
    }
}
