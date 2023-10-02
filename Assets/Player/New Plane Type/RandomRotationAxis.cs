using System.Collections;
using UnityEngine;

public class RandomRotationAxis : MonoBehaviour, IController
{
    private Vector2 _axis;
    
    public void SetupDirection()
    {
        InvokeRepeating(nameof(RandomizeAxis), 1f, 1f);
    }

    private void RandomizeAxis()
    {
        _axis.x = Random.Range(-1.0f, 1.0f);
        _axis.y = Random.Range(-1.0f, 1.0f);
    }

    public Vector3 GetAxis()
    {
        return (Vector3) _axis + transform.position;
    }
}
