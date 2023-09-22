using System;
using UnityEngine;
using UnityEngine.Events;

public class PlaneCollisions : MonoBehaviour
{
    public static bool PlaneDestroyed;
    public static UnityAction GameEnd;
    
    [SerializeField] private GameObject explosion;

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
            other.GetComponent<PowerUp>().PickUp();
            powerUpAudio.Play();
            Destroy(other.gameObject);
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
