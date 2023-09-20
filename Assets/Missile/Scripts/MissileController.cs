using System.Collections;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    public GameObject explosion;
    
    [SerializeField] private float speed;
    [SerializeField] private float lookAtSpeed;
    [SerializeField] private float speedReductionRate;
    [SerializeField] private float vanishTime;

    private Transform _player;
    private Rigidbody _rb;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating(nameof(SlowDown), speedReductionRate / speed, speedReductionRate / speed);

        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(vanishTime);
        
        explosion.SetActive(true);
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
        GetComponent<BoxCollider>().enabled = false;
        StartCoroutine(DestroyMissile());
    }

    private IEnumerator DestroyMissile()
    {
        yield return new WaitForSeconds(.3f);
        Destroy(gameObject);
    }
    

    private void SlowDown()
    {
        if (speed > 0f)
            speed -= 1f;
    }

    private void FixedUpdate()
    {
        var missileTransform = transform;
        _rb.velocity = missileTransform.up * (speed * 10f * Time.fixedDeltaTime);
        
        var difference = _player.position - missileTransform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0.0f, 0.0f, rotationZ - 90f),
            lookAtSpeed * Time.deltaTime);
    }
}
