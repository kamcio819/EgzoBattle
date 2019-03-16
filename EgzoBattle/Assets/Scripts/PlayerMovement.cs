using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rigidbody;
    public float sidewaysForce;
    [SerializeField]
    private LUNAWebSocketConnection lUNAWebSocketConnection;
  
    [SerializeField]
    private ShipAnimationController shipAnimationController;

    public GameObject sphereOne;
    public void Move(float value)
    {  
        if(value > 0) {
            transform.RotateAround(sphereOne.transform.position, Vector3.right, sidewaysForce * value * Time.deltaTime);
        }
        else if(value < 0) {
            transform.RotateAround(sphereOne.transform.position, -Vector3.right, sidewaysForce * (-1) * value * Time.deltaTime);
        }
        
    }

    public void DoAnim(float value) 
    {
        shipAnimationController.RotateAnim(sidewaysForce * value * Time.deltaTime);
    }
}
