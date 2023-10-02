using UnityEngine;

public class SpeedPowerUp : PowerUp
{
    [SerializeField] private float speedBoostTime;
    
    public override void PickUp(Component player)
    {
        var powerUpHandler = player.GetComponent<PowerUpHandler>();
        powerUpHandler.EnableSpeedBoost(speedBoostTime);
        powerUpHandler.powerUpEnabled = true;
    }
}
