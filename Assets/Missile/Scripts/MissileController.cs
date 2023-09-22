using System;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    public GameObject explosion;
    
    [SerializeField] private float speed;
    [SerializeField] private float lookAtSpeed;
    [SerializeField] private float vanishTime;

    private Transform _player;
    private Rigidbody _rb;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;

        Destroy(gameObject, vanishTime);
    }
    
    private void FixedUpdate()
    {
        _rb.velocity = transform.up * (speed * 10f * Time.fixedDeltaTime);
        
        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        var difference = _player.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0.0f, 0.0f, rotationZ - 90f),
            lookAtSpeed * Time.deltaTime);
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Wall Bounds"))
            Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded) return;
        explosion.transform.parent = null;
        explosion.SetActive(true);
    }
}
