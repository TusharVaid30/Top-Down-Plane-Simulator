using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cloudPrefab;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    
    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 1f, 1f);
    }

    private void Spawn()
    {
        var cloudPosition = new Vector3(Random.Range(minX, maxX), 0f, 0f);

        var cloudInstance = Instantiate(cloudPrefab, transform);

        cloudInstance.transform.localPosition = cloudPosition;
        cloudInstance.transform.parent = null;
    }
}
