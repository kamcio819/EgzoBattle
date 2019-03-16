using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorObject : EnemyObject
{
    [SerializeField]
    private MeteorDataObject meteorDataObject; 

    [SerializeField]
    private ParticleSystem destroyParticleSystem;

    /// <summary>
     /// OnTriggerEnter is called when the Collider other enters the trigger.
     /// </summary>
     /// <param name="other">The other Collider involved in this collision.</param>
     private void OnTriggerEnter(Collider other)
     {
         if(other.CompareTag("Planet")) {
             StartCoroutine(PlayDestroyParticleSystem());
         }
     }

   private IEnumerator PlayDestroyParticleSystem()
   {
       destroyParticleSystem.Play();

       yield return new WaitForSeconds(0.2f);

       gameObject.SetActive(false);
   }
}
