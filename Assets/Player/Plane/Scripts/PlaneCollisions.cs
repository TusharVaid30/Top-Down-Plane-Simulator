using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
        // setup power handler
        _powerUpHandler = GetComponent<PowerUpHandler>();
        PlaneDestroyed = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // wall collision
        if (collision.transform.CompareTag("Wall"))
            EndGame();
    }

    private void OnTriggerEnter(Collider other)
    {
        // power ups and missiles triggers
        if (other.CompareTag("PowerUp"))
        {
            // pick up power up
            powerUpAudio.Play();
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
        
        // triggering explosion        
        explosion.SetActive(true);
        explosion.transform.parent = null;
        
        // playing audio 
        var planeVisual = transform.GetChild(0).gameObject;
        Destroy(planeVisual);
        planeAudio.SetActive(false);
                
        GameEnd.Invoke();
    }
}
