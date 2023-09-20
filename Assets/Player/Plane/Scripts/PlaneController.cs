using UnityEngine;
using UnityEngine.InputSystem;

public class PlaneController : MonoBehaviour
{
    public float speed;
    public float upgradedSpeed;
    
    [SerializeField] private float rotationSensitivity;
    
    private Rigidbody _rb;
    private PlayerInput _playerInput;
    private bool _rotate;
    private Vector2 _axis;
    
    private void Awake()
    {
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
        if (_axis.x < 0f)
        {
            var rot = new Vector3(0f, 50f, 0f);
            transform.GetChild(1).localEulerAngles = rot;
        }
        else
        {
            var rot = new Vector3(0f, -50f, 0f);
            if (rot.y > 180)
                rot.y -= 360;
            transform.GetChild(1).localEulerAngles = rot;
        }
        _rotate = true;
    }

    private void EndMove(InputAction.CallbackContext obj)
    {
        _axis = Vector2.zero;
        _rotate = false;
        
        transform.GetChild(1).localRotation = Quaternion.identity;
    }

    private void Update()
    {
        if (_rotate)
        {
            transform.Rotate(0f, 0f, -_axis.x * rotationSensitivity * 10f * Time.deltaTime);
        }
        
        transform.GetChild(0).localRotation = Quaternion.Lerp(transform.GetChild(0).localRotation, transform.GetChild(1).localRotation, 3f * Time.deltaTime);
    }
}
