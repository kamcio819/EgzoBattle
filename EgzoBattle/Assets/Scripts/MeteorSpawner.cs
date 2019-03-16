using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour, IUpdateable
{
    [Range(25, 50)]
    public int meteorCount = 25;
    [SerializeField]
    private MeteorSpawnerController meteorSpawnerController;

    [SerializeField]
    private List<MeteorObject> meteorObjectCollection = new List<MeteorObject>();

    private float timeStep;

    private float timeConst = 10f;

   public void OnUpdate()
   { 
        meteorSpawnerController.SpawnMeteors();
   }

   public void OnStart()
   {
       for(int i = 0; i < meteorObjectCollection.Count; ++i) {
            MyObjectPoolManager.Instance.CreatePoolIfNotExists(meteorObjectCollection[i].gameObject, 3, 5, false);
       }
   }
   
}
