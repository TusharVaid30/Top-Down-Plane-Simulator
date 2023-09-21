using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHandler : MonoBehaviour
{
    public bool shieldEnabled;
    
    [SerializeField] private GameObject shieldVisual;

    private PlaneController _planeController;
    private float _startSpeed;
    private float _maxPowerUpTime;
    private float _timer;
    
    private void Start()
    {
        _planeController = GetComponent<PlaneController>();
        _startSpeed = _planeController.speed;
    }

    private void Update()
    {
        if (Time.time > _timer + _maxPowerUpTime)
        {
            DisableAllPowerUps();
        }
    }

    public void EnableShield(float time)
    {
        DisableAllPowerUps();
        _maxPowerUpTime = time;
        _timer = Time.time;
        shieldVisual.SetActive(true);
        shieldEnabled = true;
    }

    public void EnableSpeedBoost(float time)
    {
        DisableAllPowerUps();
        _maxPowerUpTime = time;
        _timer = Time.time;
        _planeController.speed = _planeController.upgradedSpeed;
    }

    private void DisableAllPowerUps()
    {
        shieldVisual.SetActive(false);
        shieldEnabled = false;
        _planeController.speed = _startSpeed;
    }
}
