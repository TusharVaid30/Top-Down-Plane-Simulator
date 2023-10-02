using UnityEngine;

public class AxisDirection : MonoBehaviour, IRotation
{
    [SerializeField] private float rotationSpeed;
    
    public void ChangeDirection(Vector3 axis)
    {
        var difference = axis - transform.position;

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        var rot = Quaternion.Euler(0.0f, 0.0f, rotationZ - 90f);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, rotationSpeed * Time.deltaTime);
    }
}