using UnityEngine;

public class ForwardMovement : MonoBehaviour, IMovement
{
    [SerializeField] private float speed;
    [SerializeField] private float upgradedSpeed;
    
    private Rigidbody _rb;

    public void SetupRigidbody()
    {
        _rb = GetComponent<Rigidbody>();
        Speed = speed;
        UpgradedSpeed = upgradedSpeed;
    }

    public void Move()
    {
        _rb.velocity = transform.up * (Speed * 10f * Time.fixedDeltaTime);
    }

    public float Speed { get; set; }
    public float UpgradedSpeed { get; set; }
}