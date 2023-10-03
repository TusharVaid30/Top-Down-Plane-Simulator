using UnityEngine;

public class ForwardMovement : MonoBehaviour, IMovement
{
    [SerializeField] private float speed;
    
    private Rigidbody _rb;

    public void SetupRigidbody()
    {
        _rb = GetComponent<Rigidbody>();
        Speed = speed;
    }

    public void Move()
    {
        _rb.velocity = transform.up * (Speed * 10f * Time.fixedDeltaTime);
    }

    public float Speed { get; set; }
}