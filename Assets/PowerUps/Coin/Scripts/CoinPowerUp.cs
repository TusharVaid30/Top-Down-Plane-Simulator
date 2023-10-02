using UnityEngine;

public class CoinPowerUp : PowerUp
{
    private ScoreCounter _scoreCounter;

    private void Start()
    {
        _scoreCounter = FindObjectOfType<ScoreCounter>();
    }

    public override void PickUp(Component scoreCounter)
    {
        _scoreCounter.CoinBonus();
    }
}
