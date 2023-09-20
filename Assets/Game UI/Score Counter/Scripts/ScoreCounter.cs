using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int currentScore;
    public int time;
    
    [SerializeField] private TMP_Text scoreCounterText;
    [SerializeField] private TMP_Text scoreCounterTextRetryMenu;
    [SerializeField] private int coinPoints;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private TMP_Text timeTextRetryMenu;
    [SerializeField] private PlaneCollisions planeCollision;
    
    private int _tempScore;
    private int _tempIncreasedScore;
    
    private void Start()
    {
        InvokeRepeating(nameof(IncreaseScore), 1f, 1f);
        InvokeRepeating(nameof(IncreaseTime), 1f, 1f);
    }

    private void IncreaseTime()
    {
        if (planeCollision.planeDestroyed) return;
        time++;
        timeText.text = "time: " + time;
        timeTextRetryMenu.text = "time: " + time;
    }
    
    public void GetUpgrade()
    {
        _tempScore = currentScore;
        _tempIncreasedScore = currentScore + coinPoints;
        scoreCounterText.color = Color.yellow;
        StartCoroutine(Upgrade());
    }

    private IEnumerator Upgrade()
    {
        while (_tempScore < _tempIncreasedScore)
        {
            yield return new WaitForSeconds(.1f);
            _tempScore++;
            currentScore = _tempScore;
            IncreaseScore();
        }
        scoreCounterText.color = Color.white;
    }
    
    private void IncreaseScore()
    {
        if (planeCollision.planeDestroyed) return;
        currentScore++;
        scoreCounterTextRetryMenu.text = "score: " + currentScore;
        scoreCounterText.GetComponent<Animator>().Play("Score Change", -1, 0f);
    }

    private void Display()
    {
        scoreCounterText.text = currentScore.ToString();
    }
}
