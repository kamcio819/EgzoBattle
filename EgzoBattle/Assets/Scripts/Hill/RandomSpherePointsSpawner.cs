using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpherePointsSpawner : MonoBehaviour
{
    [SerializeField]
    private SphereCollider sphereCollider = default;

    [SerializeField]
    private Transform sphereTransform = default;

    public void PlaceHill(GameObject hillObject)
    {
        Vector3 spawnPosition = Random.onUnitSphere * (sphereCollider.radius + 1.5f * 0.5f) + sphereTransform.position;
        hillObject.transform.position = spawnPosition;
    }
}
