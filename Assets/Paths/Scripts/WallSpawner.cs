using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public List<Transform> currentlySpawnedPath;
    
    [SerializeField] private float spawnDelay;
    [SerializeField] private GameObject[] prefabs;
    
    private void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnDelay, spawnDelay);
    }

    public bool IsObjectClose(Vector3 target, List<Transform> objs, float distance)
    {
        float minDist = distance;
        foreach (var t in objs)
        {
            float dist = Vector3.Distance(t.position, target);
            if (dist < minDist)
                return true;
        }
        return false;
    }
    
    private void Spawn()
    {
        if (IsObjectClose(transform.position, currentlySpawnedPath, 150f)) return;

        int randomIndex = Random.Range(0, prefabs.Length);
            
        var inst = Instantiate(prefabs[randomIndex], transform);
        currentlySpawnedPath.Add(inst.transform);
        
        inst.transform.localPosition = Vector3.zero;
        inst.transform.rotation = Quaternion.identity;
        inst.transform.parent = null;
    }
}
