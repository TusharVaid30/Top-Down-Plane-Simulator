using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class PowerUp : MonoBehaviour
{
    public bool enabledPowerUp = false;
    public bool respawn = true;
    public float effectTime = 5f;
    
    [SerializeField] private Collider powerUpCollider;
    [SerializeField] private Renderer powerUpRenderer;
    [SerializeField] private List<PowerUpSpawner> powerUpSpawners;
    
    protected PowerUpHandler PowerUpHandler;

    protected abstract void ApplyEffect(Transform player);
    protected abstract void EndEffect();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PowerUpHandler = other.GetComponent<PowerUpHandler>();
            
            if (PowerUpHandler.currentPowerUp)
                PowerUpHandler.currentPowerUp.EndEffect();

            powerUpCollider.enabled = false;
            powerUpRenderer.enabled = false;
            
            ApplyEffect(other.transform);
            
            PowerUpHandler.currentPowerUp = this;
            
            Destroy(gameObject, effectTime);

            enabledPowerUp = true;

            // if (respawn)
            //     powerUpSpawners[Random.Range(0, powerUpSpawners.Count)].Spawn();
        }
    }

    private void OnDestroy()
    {
        EndEffect();
        enabledPowerUp = false;
        if (PowerUpHandler)
            PowerUpHandler.currentPowerUp = null;
    }
}
