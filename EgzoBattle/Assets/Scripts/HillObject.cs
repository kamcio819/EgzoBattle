using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillObject : EnemyObject
{

     /// <summary>
     /// OnTriggerEnter is called when the Collider other enters the trigger.
     /// </summary>
     /// <param name="other">The other Collider involved in this collision.</param>
     private void OnTriggerEnter(Collider other)
     {
         if(other.CompareTag("HillBlocker")) {
             gameObject.GetComponent<MeshRenderer>().enabled = false;
         }
         if(other.CompareTag("HillUnlocker")) {
             gameObject.GetComponent<MeshRenderer>().enabled = true;
         }
     } 
}