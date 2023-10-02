using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float speed;
    public float upgradedSpeed;
    
    [SerializeField] private float rotationSpeed;

    private PlayerInputHandler _playerInputHandler;
    
    private Rigidbody _rb;
    private bool _rotate;
    private Vector2 _axis;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        _playerInputHandler = GetComponent<PlayerInputHandler>();
        
        // setting up player input
        _playerInputHandler.SetupInput();
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // move in the forward direction
        _rb.velocity = transform.up * (speed * 10f * Time.fixedDeltaTime);
    }

    private void Update()
    {
        // check if analog is active and plane is not destroyed
        if (PlaneCollisions.PlaneDestroyed) return;
        
        //rotate to analog direction
        var position = transform.position;
        var direction = (Vector3) _playerInputHandler.GetAxis() + position;
        var difference = direction - position;
        
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        
        var rot = Quaternion.Euler(0.0f, 0.0f, rotationZ - 90f);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, rotationSpeed * Time.deltaTime);
    }
}