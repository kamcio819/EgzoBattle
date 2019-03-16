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
       timeStep += Time.deltaTime;
       if(timeStep > timeConst) {
           SpawnMeteor();
       }
   }

   private void SpawnMeteor()
   {
      //throw new NotImplementedException();
   }

   public void OnStart()
   {
       int minCount = 25 / meteorObjectCollection.Count;
       int maxCount = 50 / meteorObjectCollection.Count;
       for(int i = 0; i < meteorObjectCollection.Count; ++i) {
            MyObjectPoolManager.Instance.CreatePoolIfNotExists(meteorObjectCollection[i].gameObject, 5, 15, false);
       }
   }
}
