using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public List<Transform> currentlySpawnedPath;
    
    [SerializeField] private PointerController pointerController;
    
    [SerializeField] private float spawnDelay;
    [SerializeField] private GameObject[] prefabs;
    
    private void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnDelay, spawnDelay);
    }

    public static bool IsObjectClose(Vector3 target, IEnumerable<Transform> objs, float distance)
    {
        return objs.Select(t => Vector3.Distance(t.position, target)).Any(dist => dist < distance);
    }
    
    private void Spawn()
    {
        if (IsObjectClose(transform.position, currentlySpawnedPath, 150f)) return;

        int randomIndex = Random.Range(0, prefabs.Length);
            
        var inst = Instantiate(prefabs[randomIndex], transform);
        currentlySpawnedPath.Add(inst.transform);
        pointerController.instance = inst.transform;
        
        inst.transform.localPosition = Vector3.zero;
        inst.transform.rotation = Quaternion.identity;
        inst.transform.parent = null;
    }
}
