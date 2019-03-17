using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour, IUpdateable
{
    [Range(2, 7)]
    public int meteorCount = 5;
    [SerializeField]
    private MeteorSpawnerController meteorSpawnerController;

    [SerializeField]
    public List<MeteorObject> meteorObjectCollection = new List<MeteorObject>();

    private float timeStep;

    private float timeConst = 10f;

   public void OnUpdate()
   { 
        meteorSpawnerController.SpawnMeteors(meteorCount);
   }

   public void OnStart()
   {
       for(int i = 0; i < meteorObjectCollection.Count; ++i) {
            MyObjectPoolManager.Instance.CreatePoolIfNotExists(meteorObjectCollection[i].gameObject, meteorCount, 7, false);
       }
   }
   
}
