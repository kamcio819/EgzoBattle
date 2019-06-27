using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpherePointsSpawner : MonoBehaviour
{
    [SerializeField]
    private float radius;
    
    [SerializeField]
    private Transform sphereTransform;

    public void PlaceHill(GameObject hillObject , float spawnHeight)
    {
        Vector3 spawnPosition = Random.onUnitSphere * (radius + spawnHeight * 2f) + sphereTransform.position;
        hillObject.transform.position = spawnPosition;
    }
}
