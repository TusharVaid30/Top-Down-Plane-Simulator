using System;
using System.Collections;
using UnityEngine;

public class PlaneCollisions : MonoBehaviour
{
    [SerializeField] private ScoreCounter scoreCounter;
    [SerializeField] private float powerUpTime;
    
    private PlaneController _planeController;
    private float _startSpeed;

    private void Start()
    {
        _planeController = GetComponent<PlaneController>();
        _startSpeed = _planeController.speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
            scoreCounter.GetUpgrade();
        else if (other.CompareTag("Speed Boost"))
        {
            _planeController.speed = _planeController.upgradedSpeed;
            StartCoroutine(CancelPowerUp());
        }
    }

    private IEnumerator CancelPowerUp()
    {
        yield return new WaitForSeconds(powerUpTime);
        _planeController.speed = _startSpeed;
    }
}
