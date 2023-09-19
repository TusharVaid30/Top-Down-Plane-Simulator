using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform targetPlayer;
    [SerializeField] private float cameraFollowSpeed;
    
    private Vector3 _positionDifference;

    private void Start()
    {
        _positionDifference = transform.position - targetPlayer.position;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, targetPlayer.position + _positionDifference,
            cameraFollowSpeed * Time.fixedDeltaTime);
    }
}
