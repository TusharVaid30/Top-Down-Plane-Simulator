using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class JoystickController : MonoBehaviour
{
    private PlayerInput _playerInput;
    
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerInput.actions["Move"].performed += Move;
    }

    private void Move(InputAction.CallbackContext obj)
    {
        print(obj.ReadValue<Vector2>());
    }
}
