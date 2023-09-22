using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class PlaneCollisions : MonoBehaviour
{
    public static bool PlaneDestroyed;
    public static UnityAction GameEnd;
    
    [SerializeField] private GameObject explosion;
    
    [SerializeField] private List<PowerUpSpawner> powerUpSpawners;
    
    [SerializeField] private GameObject planeAudio;
    [SerializeField] private AudioSource powerUpAudio;
    [SerializeField] private AudioSource missileAudio;
    
    private PowerUpHandler _powerUpHandler;
    
    private void Start()
    {
        _powerUpHandler = GetComponent<PowerUpHandler>();
        PlaneDestroyed = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Wall"))
            EndGame();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            var powerUpObject = other.GetComponent<PowerUp>();
            powerUpObject.PickUp();
            powerUpAudio.Play();
            Destroy(other.gameObject);
            
            if (powerUpObject.respawn)
                powerUpSpawners[Random.Range(0, powerUpSpawners.Count)].Spawn();
        }
        else if (other.CompareTag("Missile"))
        {
            missileAudio.Play();
            if (!_powerUpHandler.shieldEnabled)
                EndGame();
            Destroy(other.gameObject);
        }
    }

    private void EndGame()
    {
        PlaneDestroyed = true;
                
        explosion.SetActive(true);
        explosion.transform.parent = null;
                
        var planeVisual = transform.GetChild(0).gameObject;
        Destroy(planeVisual);
        planeAudio.SetActive(false);
                
        GameEnd.Invoke();
    }
}
