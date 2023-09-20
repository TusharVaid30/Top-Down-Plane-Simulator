using System.Collections;
using TMPro;
using UnityEngine;

public class PlaneCollisions : MonoBehaviour
{
    public bool planeDestroyed;
    
    [SerializeField] private ScoreCounter scoreCounter;
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private TMP_Text coinTextRetryMenu;
    [SerializeField] private float powerUpTime;
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject shield;
    [SerializeField] private Animator retryMenu;
    [SerializeField] private GameObject planeAudio;
    [SerializeField] private AudioSource explosionAudio;
    [SerializeField] private AudioSource powerUp;
    [SerializeField] private AudioSource missleAudio;
    
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
            coinText.text = "coins: " + _coinsCollected;
            coinTextRetryMenu.text = "coins: " + _coinsCollected;
            Destroy(other.gameObject);
            powerUp.Play();
        }
        else if (other.CompareTag("Speed Boost"))
        {
            _planeController.speed = _planeController.upgradedSpeed;
            StartCoroutine(CancelPowerUp());
            Destroy(other.gameObject);
            powerUp.Play();
        }
        else if (other.CompareTag("Shield Boost"))
        {
            _shield = true;
            shield.SetActive(true);
            StartCoroutine(CancelPowerUp());
            Destroy(other.gameObject);
            powerUp.Play();
        }
        else if (other.CompareTag("Missile"))
        {
            missleAudio.Play();
            if (!_shield)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                explosion.SetActive(true);
                planeDestroyed = true;
                GetComponents<Collider>()[0].enabled = false;
                GetComponents<Collider>()[1].enabled = false;
                StartCoroutine(OpenMenu());

                if (scoreCounter.currentScore > PlayerPrefs.GetInt("HIGHSCORE"))
                    PlayerPrefs.SetInt("HIGHSCORE", scoreCounter.currentScore);
                if (scoreCounter.time > PlayerPrefs.GetInt("TIME"))
                    PlayerPrefs.SetInt("TIME", scoreCounter.time);
                if (_coinsCollected > PlayerPrefs.GetInt("COINS"))
                    PlayerPrefs.SetInt("COINS", _coinsCollected);
                
                explosionAudio.Play();
                planeAudio.SetActive(false);
            }
            else
            {
                other.GetComponent<MissileController>().explosion.SetActive(true);
                other.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                other.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                other.transform.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }

    private IEnumerator OpenMenu()
    {
        yield return new WaitForSeconds(.3f);
        retryMenu.Play("Show Menu", -1, 0f);
    }

    private IEnumerator CancelPowerUp()
    {
        yield return new WaitForSeconds(powerUpTime);
        _planeController.speed = _startSpeed;
        _shield = false;
        shield.SetActive(false);
    }
}
