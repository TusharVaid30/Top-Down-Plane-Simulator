using UnityEngine;

public class ShieldPowerUp : PowerUp
{
    [SerializeField] private float shieldTime;
    
    private GameObject _player;
    
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void PickUp()
    {
        var powerUpHandler = _player.GetComponent<PowerUpHandler>();
        powerUpHandler.EnableShield(shieldTime);
    }
}
