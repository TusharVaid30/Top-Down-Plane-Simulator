using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput _playerInput;
    private Vector2 _axis = Vector2.up;

    public void SetupInput()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerInput.actions["Move"].performed += AnalogStickStartMoving;
    }

    private void AnalogStickStartMoving(InputAction.CallbackContext obj)
    {
        // set axis value on analog rotation
        _axis = obj.ReadValue<Vector2>();
    }

    public Vector2 GetAxis()
    {
        return _axis;
    }
}