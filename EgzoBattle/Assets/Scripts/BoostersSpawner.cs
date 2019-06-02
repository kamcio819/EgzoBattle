using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostersSpawner : MonoBehaviour, IUpdateable
{

    [Range(10, 200)]
    public int howMuchHills = 100;

    [SerializeField]
    private RandomSpherePointsSpawner randomSpherePointsSpawner;

    [SerializeField]
    private List<BoosterObject> boosterObjectCollector = new List<BoosterObject>();

   public void OnStart()
   {
      for (int i = 0; i < boosterObjectCollector.Count; ++i)
      {
         MyObjectPoolManager.Instance.CreatePoolIfNotExists(boosterObjectCollector[i].gameObject, 40, 60, false);
      }

      PlaceHill("booster Variant");
      PlaceHill("booster2 Variant");
      
   }

   public void OnUpdate()
   {
      //
   }

   private void PlaceHill(string name)
   {
      List<GameObject> poolObjects = MyObjectPoolManager.Instance.GetAllPool(name);
      for (int i = 0; i < poolObjects.Count; ++i)
      {
         randomSpherePointsSpawner.PlaceHill(poolObjects[i]);
      }
   }
}
