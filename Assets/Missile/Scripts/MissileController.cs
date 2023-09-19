using UnityEngine;

public class MissileController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lookAtSpeed;
    [SerializeField] private float missileVanishTime;
    
    private Transform _player;
    private Rigidbody _rb;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating(nameof(SlowDown), missileVanishTime / speed, missileVanishTime / speed);
    }

    private void SlowDown()
    {
        if (speed > 0f)
            speed -= 1f;
    }

    private void FixedUpdate()
    {
        var missileTransform = transform;
        _rb.velocity = missileTransform.up * speed * 10f * Time.fixedDeltaTime;
        
        var difference = _player.position - missileTransform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0.0f, 0.0f, rotationZ - 90f),
            lookAtSpeed * Time.deltaTime);
    }
}
