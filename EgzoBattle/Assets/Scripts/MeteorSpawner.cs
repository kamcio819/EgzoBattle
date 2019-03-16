using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour, IUpdateable
{
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

   public void Start()
   {
       for(int i = 0; i < meteorObjectCollection.Count; ++i) {
        MyObjectPoolManager.Instance.CreatePoolIfNotExists(meteorObjectCollection[i].gameObject, 10, 25, false);
       }
   }
}
