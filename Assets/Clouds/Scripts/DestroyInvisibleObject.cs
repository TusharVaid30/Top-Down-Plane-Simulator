using System.Collections;
using UnityEngine;

public class DestroyInvisibleObject : MonoBehaviour
{
    [SerializeField] private bool shouldDestroy = true;

    private bool _canBeDestroyed;
    
    private void Start()
    {
        if (shouldDestroy)
            StartCoroutine(Delay());
    }

    private void OnBecameInvisible()
    {
        if (_canBeDestroyed)
            Destroy(transform.parent.gameObject);
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(3f);
        _canBeDestroyed = true;
    }
}
