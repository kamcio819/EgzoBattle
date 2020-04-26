using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour, IInteractable
{
    [Range(2, 7)]
    public int meteorCount = 5;

    [SerializeField]
    private MeteorSpawnerController meteorSpawnerController = default;

    [SerializeField]
    public List<MeteorObject> meteorObjectCollection = default;

    public void OnUpdate()
    {
        meteorSpawnerController.SpawnMeteors(meteorCount);
    }

    public void OnStart()
    {
        for (int i = 0; i < meteorObjectCollection.Count; ++i)
        {
            MyObjectPoolManager.Instance.CreatePoolIfNotExists(meteorObjectCollection[i].gameObject, meteorCount, 7, false);
        }
    }

}
