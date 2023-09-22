using UnityEngine;
using Random = UnityEngine.Random;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private WallSpawner wallSpawner;
    [SerializeField] private PointerController pointerController;

    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    
    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        if (WallSpawner.IsObjectClose(transform.position, wallSpawner.currentlySpawnedPath, 100f)) return;
        
        var spawnPos = new Vector3(Random.Range(minX, maxX), 0f, 0f);

        int randomIndex = Random.Range(0, prefabs.Length);
        var inst = Instantiate(prefabs[randomIndex], transform);
        pointerController.instance = inst.transform;

        inst.transform.localPosition = spawnPos;
        inst.transform.rotation = Quaternion.identity;
        inst.transform.parent = null;
    }
}
