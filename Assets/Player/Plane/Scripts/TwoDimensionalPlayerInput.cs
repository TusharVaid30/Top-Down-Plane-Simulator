using UnityEngine;
using UnityEngine.InputSystem;

public class TwoDimensionalPlayerInput : MonoBehaviour, IController
{
    private PlayerInput _playerInput;
    private Vector2 _axis = Vector2.up;

    public void SetupDirection()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerInput.actions["Move"].performed += SetAxis;
    }

    private void SetAxis(InputAction.CallbackContext obj)
    {
        _axis = obj.ReadValue<Vector2>();
    }

    public Vector3 GetAxis()
    {
        return (Vector3) _axis + transform.position;
    }
}