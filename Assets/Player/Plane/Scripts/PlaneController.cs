using UnityEngine;
using UnityEngine.InputSystem;

public class PlaneController : MonoBehaviour
{
    public float speed;
    public float upgradedSpeed;
    
    [SerializeField] private float rotationSpeed;
    
    private Rigidbody _rb;
    private PlayerInput _playerInput;
    private bool _rotate;
    private Vector2 _axis;
    
    private void Awake()
    {
        Application.targetFrameRate = 60;
        
        _playerInput = GetComponent<PlayerInput>();
        _playerInput.actions["Move"].performed += Move;
        _playerInput.actions["Move"].canceled += EndMove;
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rb.velocity = transform.up * (speed * 10f * Time.fixedDeltaTime);
    }

    private void Move(InputAction.CallbackContext obj)
    {
        _axis = obj.ReadValue<Vector2>();
        _rotate = true;
    }

    private void EndMove(InputAction.CallbackContext obj)
    {
        _axis = Vector2.zero;
        _rotate = false;
    }

    private void Update()
    {
        if (!_rotate || PlaneCollisions.PlaneDestroyed) return;
        var position = transform.position;
        var direction = (Vector3) _axis + position;
        var difference = direction - position;
            
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            
        var rot = Quaternion.Euler(0.0f, 0.0f, rotationZ - 90f);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, rotationSpeed * Time.deltaTime);
    }
}
