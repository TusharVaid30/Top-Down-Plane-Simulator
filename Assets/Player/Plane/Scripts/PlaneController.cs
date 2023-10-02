using UnityEngine;

public class PlaneController : MonoBehaviour
{
    private IController _controllerHandler;
    private IMovement _movementHandler;
    private IRotation _rotation;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        
        _controllerHandler = GetComponent<IController>();
        _controllerHandler.SetupDirection();

        _movementHandler = GetComponent<IMovement>();
        _movementHandler.SetupRigidbody();

        _rotation = GetComponent<IRotation>();
    }

    private void FixedUpdate()
    {
        _movementHandler.Move();
    }

    private void Update()
    {
        if (PlaneCollisions.PlaneDestroyed) return;
        
        _rotation.ChangeRotation(_controllerHandler.GetAxis());
    }
}