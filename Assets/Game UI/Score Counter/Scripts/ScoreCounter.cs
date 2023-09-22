using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int currentScore;
    public int time;

    [SerializeField] private int coinBonusPoints;
    
    [SerializeField] private TMP_Text scoreCounterText;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private TMP_Text coinText;

    [SerializeField] private ScoreManager scoreManager;
    
    private int _tempScore;
    private int _tempIncreasedScore;
    
    private int _coinsCollected;

    private void Start()
    {
        InvokeRepeating(nameof(IncreaseTime), 1f, 1f);
    }

    private void Awake()
    {
        PlaneCollisions.GameEnd += UpdateFinalScores;
    }

    private void OnDestroy()
    {
        PlaneCollisions.GameEnd -= UpdateFinalScores;
    }

    public void CoinBonus()
    {
        _coinsCollected++;
        coinText.text = "coins: " + _coinsCollected;
        
        _tempScore = currentScore;
        _tempIncreasedScore = time + _coinsCollected * coinBonusPoints;
        scoreCounterText.color = Color.yellow;
        
        StartCoroutine(BonusAnimation());
    }

    private IEnumerator BonusAnimation()
    {
        while (_tempScore < _tempIncreasedScore)
        {
            yield return new WaitForSeconds(.1f);
            _tempScore++;
            currentScore = _tempScore;
            IncreaseScore();
        }
        scoreCounterText.color = Color.white;

        currentScore = time + _coinsCollected * coinBonusPoints;
    }

    private void IncreaseScore()
    {
        currentScore++;
        scoreCounterText.GetComponent<Animator>().Play("Score Change", -1, 0f);
    }
    
    private void IncreaseTime()
    {
        if (PlaneCollisions.PlaneDestroyed) return;
        IncreaseScore();
        time++;
        timeText.text = "time: " + time;
    }

    private void Display()
    {
        scoreCounterText.text = currentScore.ToString();
    }

    private void UpdateFinalScores()
    {
        scoreManager.DisplayInRetryMenu(time, _coinsCollected, time + _coinsCollected * coinBonusPoints);
    }
}
