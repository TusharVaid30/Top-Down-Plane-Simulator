using UnityEngine;
using UnityEngine.InputSystem;

public interface IController
{
    void SetupDirection();
    Vector3 GetAxis();
}