using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour, IUpdateable
{

    [SerializeField]
    private List<MeteorObject> meteorObjectCollection = new List<MeteorObject>();

   public void OnUpdate()
   {
      
   }
}
