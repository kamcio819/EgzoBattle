using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawnerController : MonoBehaviour
{
    [SerializeField]
    private GameObject meteorPlaceForSpawning;

    [SerializeField]
    private GameObject playerPlaceHolder;
    private float timeStep;
    private float timeConst = 4f;
    public void SpawnMeteors() {
        timeStep += Time.deltaTime;
        if(timeStep > timeConst) {
            SpawnMeteor();
            timeStep = 0;
       }
    }

    
   private void SpawnMeteor()
   {
      GameObject meteor = MyObjectPoolManager.Instance.GetObject("Meteor", true);
      SetPosition(meteor);
      RotateMeteor(meteor);
      meteor.GetComponent<Rigidbody>().AddForce(meteor.transform.forward * 5f, ForceMode.Acceleration);
   }

   private void RotateMeteor(GameObject meteor)
   {
       Vector3 direction = (playerPlaceHolder.transform.position - meteor.transform.position).normalized;
 
       meteor.GetComponent<Rigidbody>().velocity = direction * 5f;

   }

   private void SetPosition(GameObject meteor)
   {
      meteor.transform.position = new Vector3(
                Random.Range(meteorPlaceForSpawning.transform.position.x - 5f, meteorPlaceForSpawning.transform.position.x + 15f),
                Random.Range(meteorPlaceForSpawning.transform.position.y - 10f, meteorPlaceForSpawning.transform.position.y - 5f),
                Random.Range(meteorPlaceForSpawning.transform.position.z + 10f, meteorPlaceForSpawning.transform.position.z + 25f)
            );
   }
}
