using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawnerController : MonoBehaviour
{
    private float timeStep;
    private float timeConst = 10f;
    public void SpawnMeteors() {
        timeStep += Time.deltaTime;
       if(timeStep > timeConst) {
           SpawnMeteor();
       }
    }

    
   private void SpawnMeteor()
   {
      GameObject meteor = MyObjectPoolManager.Instance.GetObject("Meteor", true);
   }

}
