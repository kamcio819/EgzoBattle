using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoosterManager : MonoBehaviour
{
    public RotateSphere rotateSphere;

    [Header("Speed Booster")]
    [SerializeField] private GameObject sphere;
    [SerializeField] private float speedGivenByBooster;
    [SerializeField] private float timeInHigherSpeed;
    
    [Header("Up Booster")]
    //[SerializeField] GameObject spaceShipModel;
    [SerializeField] private float timeInAir;
    private Rigidbody spaceshipRigidbody;

    private void Start()
    {
        spaceshipRigidbody = GetComponent<Rigidbody>();
        var sphereCurrentSpeedRotation = sphere.GetComponent<RotateSphere>().speed;
    } 
    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "BoosterObstacle")
       {
        //    AddSpeedOverTime();
       }

       if(other.tag == "RaiseObstacle")
       {
           StartCoroutine(AddForceToShipOverTime());
       }  
    }

    private IEnumerator AddForceToShipOverTime()
    {
        var timer = 0.0f;
        while (timer < timeInAir)
        {
           timer += Time.fixedDeltaTime;
           spaceshipRigidbody.AddForce(new Vector3(0,0,50));
           yield return new WaitForFixedUpdate();       
        }       
    }
    private void AddSpeedToShipOverTime()
    {
        var timer =0.0f;
        while(timer < timeInHigherSpeed)
        {
            timer += Time.deltaTime;
            sphere.transform.Rotate(Vector3.up, speedGivenByBooster * Time.deltaTime);
        }
    }

}
