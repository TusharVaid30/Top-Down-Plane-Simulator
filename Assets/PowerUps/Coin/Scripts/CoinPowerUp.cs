using UnityEngine;

public class CoinPowerUp : PowerUp
{
    private ScoreCounter _scoreCounter;

    private void Start()
    {
        var scoreCounterGo = GameObject.FindGameObjectWithTag("ScoreCounter");
        _scoreCounter = scoreCounterGo.GetComponent<ScoreCounter>();
    }

    public override void PickUp()
    {
        _scoreCounter.CoinBonus();
    }
}
