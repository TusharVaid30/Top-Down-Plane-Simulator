using UnityEngine;

public class PlaneCollisions : MonoBehaviour
{
    public bool planeDestroyed;
    
    [SerializeField] private ScoreCounter scoreCounter;
    [SerializeField] private GameObject explosion;
    [SerializeField] private Animator retryMenu;
    [SerializeField] private GameObject planeAudio;
    [SerializeField] private AudioSource explosionAudio;
    [SerializeField] private AudioSource powerUp;
    [SerializeField] private AudioSource missileAudio;
    
    private PowerUpHandler _powerUpHandler;
    
    private void Start()
    {
        _powerUpHandler = GetComponent<PowerUpHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            other.GetComponent<PowerUp>().PickUp();
            powerUp.Play();
        }
        else if (other.CompareTag("Missile"))
        {
            missileAudio.Play();
            if (!_powerUpHandler.shieldEnabled)
            {
                planeDestroyed = true;
                explosion.SetActive(true);
                explosion.transform.parent = null;
                retryMenu.Play("Show Menu", -1, 0f);
                
                explosionAudio.Play();
                planeAudio.SetActive(false);

                var planeVisual = transform.GetChild(0).gameObject;
                Destroy(planeVisual);

                if (scoreCounter.currentScore > PlayerPrefs.GetInt("HIGHSCORE"))
                    PlayerPrefs.SetInt("HIGHSCORE", scoreCounter.currentScore);
                if (scoreCounter.time > PlayerPrefs.GetInt("TIME"))
                    PlayerPrefs.SetInt("TIME", scoreCounter.time);
                // if (_coinsCollected > PlayerPrefs.GetInt("COINS"))
                //     PlayerPrefs.SetInt("COINS", _coinsCollected);
            }
        }
        Destroy(other.gameObject);
    }
}
