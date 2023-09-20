using System.Collections;
using UnityEngine;

public class DestroyCloud : MonoBehaviour
{
    private bool _canBeDestroyed;
    
    private void Start()
    {
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
