using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorObject : EnemyObject
{
    [SerializeField]
    private MeteorDataObject meteorDataObject; 

    /// <summary>
     /// OnTriggerEnter is called when the Collider other enters the trigger.
     /// </summary>
     /// <param name="other">The other Collider involved in this collision.</param>
     private void OnCollisionEnter(Collision other)
     {
         if(other.collider.CompareTag("Planet")) {
             gameObject.SetActive(false);
         }
     }  
}
