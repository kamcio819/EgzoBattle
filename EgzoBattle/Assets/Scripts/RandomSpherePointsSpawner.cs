using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpherePointsSpawner : MonoBehaviour
{
    [SerializeField]
    private SphereCollider sphereCollider;

    [SerializeField]
    private Transform sphereTransform;

    public void SpawnHill(GameObject hillObject) {
        Vector3 spawnPosition = Random.onUnitSphere * (sphereCollider.radius + 1.5f * 0.5f) + sphereTransform.position;
        GameObject newCharacter = Instantiate(hillObject, spawnPosition, Quaternion.identity);
    }
}
