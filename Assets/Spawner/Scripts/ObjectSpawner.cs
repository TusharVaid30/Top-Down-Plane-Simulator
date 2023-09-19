using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float spawnDelay;
    
    private void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnDelay, spawnDelay);
    }

    private void Spawn()
    {
        var spawnPos = new Vector3(Random.Range(minX, maxX), 0f, 0f);

        var inst = Instantiate(prefab, transform);

        inst.transform.localPosition = spawnPos;
        inst.transform.parent = null;
    }
}
