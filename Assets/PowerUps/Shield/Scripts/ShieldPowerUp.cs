using UnityEngine;

public class ShieldPowerUp : PowerUp
{
    [SerializeField] private float shieldTime;

    public override void PickUp(Component player)
    {
        var powerUpHandler = player.GetComponent<PowerUpHandler>();
        powerUpHandler.EnableShield(shieldTime);
        powerUpHandler.powerUpEnabled = true;
    }
}
