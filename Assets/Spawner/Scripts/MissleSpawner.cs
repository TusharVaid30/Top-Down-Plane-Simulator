using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MissileSpawner : MonoBehaviour
{
    [SerializeField] private PointerController pointerController;
    
    [SerializeField] private GameObject prefab;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float spawnDelay;

    private Transform _missileInstance;
    
    private void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnDelay, spawnDelay);
    }

    private void Spawn()
    {
        var spawnPos = new Vector3(Random.Range(minX, maxX), 0f, 0f);

        var inst = Instantiate(prefab, transform);

        pointerController.instance = inst.transform;
        
        _missileInstance = inst.transform;
        _missileInstance.localPosition = spawnPos;
        _missileInstance.rotation = Quaternion.identity;
        _missileInstance.parent = null;
    }
}
