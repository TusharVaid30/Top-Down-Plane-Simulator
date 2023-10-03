using UnityEngine;

public class SpeedPowerUp : PowerUp
{
    [SerializeField] private float upgradedSpeed;

    private IMovement _playerInstance;
    private float _startSpeed;

    protected override void ApplyEffect(Transform player)
    {
        _playerInstance = player.GetComponent<IMovement>();
        _startSpeed = _playerInstance.Speed;
        _playerInstance.Speed = upgradedSpeed;
    }

    protected override void EndEffect()
    {
        if (_playerInstance != null)
            _playerInstance.Speed = _startSpeed;
    }
}
