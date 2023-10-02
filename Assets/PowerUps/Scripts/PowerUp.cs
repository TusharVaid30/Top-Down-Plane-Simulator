using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    public bool respawn = true;
    
    public abstract void PickUp(Component affectedComponent);
}
