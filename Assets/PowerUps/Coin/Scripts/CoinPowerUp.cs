using UnityEngine;

public class CoinPowerUp : PowerUp
{
    private ScoreCounter _scoreCounter;

    private void Start()
    {
        _scoreCounter = FindObjectOfType<ScoreCounter>();
    }

    protected override void ApplyEffect(Transform scoreCounter)
    {
        _scoreCounter.CoinBonus();
    }

    protected override void EndEffect()
    {
        
    }
}
