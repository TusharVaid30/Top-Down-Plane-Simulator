using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private WallSpawner wallSpawner;

    [SerializeField] private GameObject[] prefabs;
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

        if (prefabs[0].CompareTag("PowerUp"))
            if (wallSpawner.IsObjectClose(transform.position, wallSpawner.currentlySpawnedPath, 100f)) return;

        int randomIndex = Random.Range(0, prefabs.Length);
        var inst = Instantiate(prefabs[randomIndex], transform);

        inst.transform.localPosition = spawnPos;
        inst.transform.rotation = Quaternion.identity;
        inst.transform.parent = null;
    }
}
