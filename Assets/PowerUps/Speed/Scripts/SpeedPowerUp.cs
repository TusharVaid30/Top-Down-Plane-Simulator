using UnityEngine;

public class SpeedPowerUp : PowerUp
{
    [SerializeField] private float speedBoostTime;

    private GameObject _player;
    
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    
    public override void PickUp()
    {
        var powerUpHandler = _player.GetComponent<PowerUpHandler>();
        powerUpHandler.EnableSpeedBoost(speedBoostTime);
        powerUpHandler.powerUpEnabled = true;
    }
}
