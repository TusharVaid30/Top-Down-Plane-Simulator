using UnityEngine;

public class PlaneController : MonoBehaviour
{
    private IController _controllerHandler;
    private IMovement _movementHandler;
    private IRotation _rotation;

    private void Awake()
    {
        // setting up target frame rate for android
        Application.targetFrameRate = 60;
        
        // setting up controller for input type (AI or player)
        _controllerHandler = GetComponent<IController>();
        _controllerHandler.SetupDirection();

        // setting up movement type
        _movementHandler = GetComponent<IMovement>();
        _movementHandler.SetupRigidbody();

        // setting up rotation type 
        _rotation = GetComponent<IRotation>();
    }

    private void FixedUpdate()
    {
        // move in the forward direction
        _movementHandler.Move();
    }

    private void Update()
    {
        // check if analog is active and plane is not destroyed
        if (PlaneCollisions.PlaneDestroyed) return;
        
        // rotate to axis direction
        _rotation.ChangeDirection(_controllerHandler.GetAxis());
    }
}