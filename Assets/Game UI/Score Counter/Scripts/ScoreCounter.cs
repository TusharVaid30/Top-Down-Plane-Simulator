using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreCounterText;
    [SerializeField] private int coinPoints;
    [SerializeField] private TMP_Text timeText;
    
    private int _currentScore;
    private int _tempScore;
    private int _tempIncreasedScore;
    private int _time;
    
    private void Start()
    {
        InvokeRepeating(nameof(IncreaseScore), 1f, 1f);
        InvokeRepeating(nameof(IncreaseTime), 1f, 1f);
    }

    private void IncreaseTime()
    {
        _time++;
        timeText.text = "time: " + _time;
    }
    
    public void GetUpgrade()
    {
        _tempScore = _currentScore;
        _tempIncreasedScore = _currentScore + coinPoints;
        StartCoroutine(Upgrade());
    }

    private IEnumerator Upgrade()
    {
        while (_tempScore < _tempIncreasedScore)
        {
            yield return new WaitForSeconds(.1f);
            _tempScore++;
            _currentScore = _tempScore;
            IncreaseScore();
        }
    }
    
    private void IncreaseScore()
    {
        _currentScore++;
        scoreCounterText.GetComponent<Animator>().Play("Score Change", -1, 0f);
    }

    private void Display()
    {
        scoreCounterText.text = _currentScore.ToString();
    }
}
