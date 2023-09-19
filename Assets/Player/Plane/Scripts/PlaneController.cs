using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlaneController : MonoBehaviour
{
    [SerializeField] private float speed;
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
        _rb.velocity = transform.up * speed * 10f * Time.fixedDeltaTime;
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
        if (_rotate)
            transform.Rotate(0f, 0f, -_axis.x * rotationSensitivity);
    }
}
