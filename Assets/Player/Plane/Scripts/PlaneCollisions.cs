using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class PlaneCollisions : MonoBehaviour
{
    [SerializeField] private ScoreCounter scoreCounter;
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private float powerUpTime;

    private int _coinsCollected;
    private PlaneController _planeController;
    private float _startSpeed;
    private bool _shield;
    
    private void Start()
    {
        _planeController = GetComponent<PlaneController>();
        _startSpeed = _planeController.speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            scoreCounter.GetUpgrade();
            _coinsCollected++;
            coinText.text = "coin: " + _coinsCollected;
        }
        else if (other.CompareTag("Speed Boost"))
        {
            _planeController.speed = _planeController.upgradedSpeed;
            StartCoroutine(CancelPowerUp());
        }
        else if (other.CompareTag("Shield Boost"))
        {
            _shield = true;
            StartCoroutine(CancelPowerUp());
        }
        else if (other.CompareTag("Missile"))
        {
            if (!_shield)
                Destroy(gameObject);
        }
    }

    private IEnumerator CancelPowerUp()
    {
        yield return new WaitForSeconds(powerUpTime);
        _planeController.speed = _startSpeed;
        _shield = false;
    }
}
