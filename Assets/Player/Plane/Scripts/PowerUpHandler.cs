using UnityEngine;

public class PowerUpHandler : MonoBehaviour
{
    public bool powerUpEnabled;
    public bool shieldEnabled;

    public PowerUp currentPowerUp;
    
    public GameObject shieldVisual;

    private IMovement _planeMovement;
    private float _startSpeed;
    private float _maxPowerUpTime;
    private float _timer;
    private static readonly int StartBlinking = Animator.StringToHash("Start Blinking");

    private void Start()
    {
        _planeMovement = GetComponent<IMovement>();
        _startSpeed = _planeMovement.Speed;
    }

    private void Update()
    {
        if (!powerUpEnabled) return;
        // if (Time.time > _timer + _maxPowerUpTime)
        //     DisableAllPowerUps();
        // else if (Time.time > _timer + _maxPowerUpTime - 2f && shieldEnabled)
        //     shieldVisual.GetComponent<Animator>().SetTrigger(StartBlinking);
    }

    public void EnableShield(float time)
    {
        DisableAllPowerUps();
        ResetTimer(time);
        shieldVisual.SetActive(true);
        shieldEnabled = true;
    }

    public void EnableSpeedBoost(float time)
    {
        DisableAllPowerUps();
        ResetTimer(time);
    }

    private void DisableAllPowerUps()
    {
        if (shieldVisual.activeInHierarchy)
            shieldVisual.GetComponent<Animator>().ResetTrigger(StartBlinking);
        shieldVisual.SetActive(false);
        shieldEnabled = false;
        _planeMovement.Speed = _startSpeed;
    }

    private void ResetTimer(float time)
    {
        _maxPowerUpTime = time;
        _timer = Time.time;
    }
}
