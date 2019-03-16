using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RandomSpherePointsSpawner))]
public class HillsSpawner : MonoBehaviour, IUpdateable
{
    [Range(50, 150)]
    public int howMuchHills = 100;

    [SerializeField]
    private RandomSpherePointsSpawner randomSpherePointsSpawner;

    [SerializeField]
    private List<HillObject> hillObjectCollection = new List<HillObject>();

    private bool shouldRandomizeAgain = true;

    public void OnUpdate()
    {
        
    }

    public void Start()
    {
       for(int i = 0; i < hillObjectCollection.Count; ++i) {
        MyObjectPoolManager.Instance.CreatePoolIfNotExists(hillObjectCollection[i].gameObject, 50, 150, false);
       }

       List<GameObject> poolObjects = MyObjectPoolManager.Instance.GetAllPool("Hill");
       for(int i = 0; i < poolObjects.Count; ++i) {
           randomSpherePointsSpawner.PlaceHill(poolObjects[i]);
       }
    }
}
