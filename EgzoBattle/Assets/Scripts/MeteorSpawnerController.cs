using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawnerController : MonoBehaviour
{   
    [Range(5,10)]
    [Tooltip("Change meteors speed")]
    public int meteorSpeed = 5;
    [SerializeField]
    private GameObject meteorPlaceForSpawning;

    [SerializeField]
    private GameObject playerPlaceHolder;

    [SerializeField]
    private MeteorSpawner meteorSpawner;

    private float timeStep;

    [SerializeField]
    [Tooltip("Change meteors spawning frequency (seconds timestep)")]
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
       for(int i = 0; i < meteorSpawner.meteorObjectCollection.Count; ++i) {
            GameObject meteor = MyObjectPoolManager.Instance.GetObject(meteorSpawner.meteorObjectCollection[i].gameObject, true);
            if(meteor != null) {
                SetPosition(meteor);
                RotateMeteor(meteor);
                meteor.GetComponent<Rigidbody>().AddForce(meteor.transform.forward * 5f, ForceMode.Acceleration);
            }
       }
      
   }

   private void RotateMeteor(GameObject meteor)
   {
        Vector3 direction = (playerPlaceHolder.transform.position - meteor.transform.position).normalized;
 
        meteor.GetComponent<Rigidbody>().velocity = direction * meteorSpeed;
   }

   private void SetPosition(GameObject meteor)
   {
        Vector3 meteorCeneterPlace = meteorPlaceForSpawning.transform.position;
        meteor.transform.position = new Vector3(
                Random.Range(meteorCeneterPlace.x - 15f, meteorCeneterPlace.x + 15f),
                Random.Range(meteorCeneterPlace.y - 10f, meteorCeneterPlace.y - 5f),
                Random.Range(meteorCeneterPlace.z + 5f, meteorCeneterPlace.z + 45f));
   }
}
