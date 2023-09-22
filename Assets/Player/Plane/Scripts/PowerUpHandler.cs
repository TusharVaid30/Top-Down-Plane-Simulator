using UnityEngine;

public class PowerUpHandler : MonoBehaviour
{
    public bool powerUpEnabled;
    public bool shieldEnabled;

    [SerializeField] private GameObject shieldVisual;

    private PlaneController _planeController;
    private float _startSpeed;
    private float _maxPowerUpTime;
    private float _timer;
    private static readonly int StartBlinking = Animator.StringToHash("Start Blinking");

    private void Start()
    {
        _planeController = GetComponent<PlaneController>();
        _startSpeed = _planeController.speed;
    }

    private void Update()
    {
        if (!powerUpEnabled) return;
        if (Time.time > _timer + _maxPowerUpTime)
            DisableAllPowerUps();
        else if (Time.time > _timer + _maxPowerUpTime - 2f && shieldEnabled)
            shieldVisual.GetComponent<Animator>().SetTrigger(StartBlinking);
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
        _planeController.speed = _planeController.upgradedSpeed;
    }

    private void DisableAllPowerUps()
    {
        if (shieldVisual.activeInHierarchy)
            shieldVisual.GetComponent<Animator>().ResetTrigger(StartBlinking);
        shieldVisual.SetActive(false);
        shieldEnabled = false;
        _planeController.speed = _startSpeed;
    }

    private void ResetTimer(float time)
    {
        _maxPowerUpTime = time;
        _timer = Time.time;
    }
}
