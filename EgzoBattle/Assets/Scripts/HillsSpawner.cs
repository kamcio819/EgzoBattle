using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RandomSpherePointsSpawner))]
public class HillsSpawner : MonoBehaviour, IUpdateable
{
    [Range(50, 200)]
    public int howMuchHills = 100;

    [SerializeField]
    private RandomSpherePointsSpawner randomSpherePointsSpawner;

    [SerializeField]
    private List<HillObject> hillObjectCollection = new List<HillObject>();

    private bool shouldRandomizeAgain = true;

    public void OnUpdate()
    {
        if(shouldRandomizeAgain) {

        }
    }

    public void OnStart()
   {
      for (int i = 0; i < hillObjectCollection.Count; ++i)
      {
         MyObjectPoolManager.Instance.CreatePoolIfNotExists(hillObjectCollection[i].gameObject, 100, 150, false);
      }

      PlaceHill("Hill");
      PlaceHill("hill1");
      PlaceHill("hill2");
      PlaceHill("hill3");
      PlaceHill("hill4");
      PlaceHill("hill5");
      PlaceHill("hill6");
      PlaceHill("hill7");
      PlaceHill("hill8");
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
