using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RandomSpherePointsSpawner))]
public class HillsSpawner : MonoBehaviour, IUpdateable
{
    public int howMuchHills = 10;

    [SerializeField]
    private RandomSpherePointsSpawner randomSpherePointsSpawner;

    [SerializeField]
    private List<HillObject> hillObjectCollection = new List<HillObject>();

    private bool spawningEnabled = true;

   public void OnUpdate()
   {
       if(spawningEnabled) {
            for(int i = 0; i < hillObjectCollection.Count; ++i) {
                for(int j = 0; j < howMuchHills; ++j) {
                    randomSpherePointsSpawner.SpawnHill(hillObjectCollection[i].gameObject);
                }
            }
            spawningEnabled = false;
        }  
   }
}
