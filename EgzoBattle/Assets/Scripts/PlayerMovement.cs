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
    public void MoveRight()
    {
        transform.RotateAround(sphereOne.transform.position, Vector3.right, sidewaysForce * Time.deltaTime);

        shipAnimationController.RotateAnimRight(sidewaysForce);
    }

    public void MoveLeft()
    {
        transform.RotateAround(sphereOne.transform.position, Vector3.left, sidewaysForce * Time.deltaTime);

        shipAnimationController.RotateAnimLeft(sidewaysForce);
    }
}
