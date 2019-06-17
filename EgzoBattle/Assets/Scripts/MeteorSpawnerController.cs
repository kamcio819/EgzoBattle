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
    private float singleMeteorCounter = 0f;

    [SerializeField]
    [Tooltip("Change meteors spawning frequency (seconds timestep)")]
    private float timeConst = 8f;

    public void SpawnMeteors(int count) {
        timeStep += Time.deltaTime;
        if(timeStep > timeConst / MenuManager.instance.GameDifficulty) {
            SpawnMeteor(count);
            timeStep = 0;
       }
    }

   private void SpawnMeteor(int count)
   {
       for(int j = 0; j < count * MenuManager.instance.GameDifficulty; ++j) {
            for(int i = 0; i < meteorSpawner.meteorObjectCollection.Count; ++i) {
                    singleMeteorCounter += Time.deltaTime;
                    if(singleMeteorCounter > 0.4f) {
                         GameObject meteor = MyObjectPoolManager.Instance.GetObject(meteorSpawner.meteorObjectCollection[Random.Range(0, meteorSpawner.meteorObjectCollection.Count)].gameObject, true);
                         if(meteor != null) {
                              SetPosition(meteor);
                              RotateMeteor(meteor);
                         }
                         singleMeteorCounter = 0f;
                    }
            }
       }
      
   }

   private void RotateMeteor(GameObject meteor)
   {
        Vector3 direction = (playerPlaceHolder.transform.position - meteor.transform.position).normalized;
 
        meteor.GetComponent<Rigidbody>().velocity = direction * Random.Range(5, 10) * MenuManager.instance.GameDifficulty/2f * 2;
   }

   private void SetPosition(GameObject meteor)
   {
        Vector3 meteorCeneterPlace = meteorPlaceForSpawning.transform.position;
        meteor.transform.position = new Vector3(
                Random.Range(meteorCeneterPlace.x - 50f, meteorCeneterPlace.x + 50f),
                Random.Range(meteorCeneterPlace.y - 10f, meteorCeneterPlace.y - 5f),
                Random.Range(meteorCeneterPlace.z - 10f, meteorCeneterPlace.z + 80f));
   }
}
