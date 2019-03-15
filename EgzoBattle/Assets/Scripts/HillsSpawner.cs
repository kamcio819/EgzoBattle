using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RandomSpherePointsSpawner))]
public class HillsSpawner : MonoBehaviour, IUpdateable
{
    [SerializeField]
    private RandomSpherePointsSpawner randomSpherePointsSpawner;

    [SerializeField]
    private List<HillObject> hillObjectCollection = new List<HillObject>();

   public void OnUpdate()
   {
      for(int i = 0; i < hillObjectCollection.Count; ++i) {
          //randomSpherePointsSpawner.SpawnHill(hillObjectCollection[i]);
      }
   }
}
