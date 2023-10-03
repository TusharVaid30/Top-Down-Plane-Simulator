using UnityEngine;

public class ShieldPowerUp : PowerUp
{
    protected override void ApplyEffect(Transform player)
    {
        PowerUpHandler.shieldEnabled = true;
        PowerUpHandler.shieldVisual.SetActive(true);
    }

    protected override void EndEffect()
    {
        if (PowerUpHandler == null) return;
        PowerUpHandler.shieldEnabled = false;
        PowerUpHandler.shieldVisual.SetActive(false);
    }
}
