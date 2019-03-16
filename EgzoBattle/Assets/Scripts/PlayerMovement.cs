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

    public GameObject sphereOne;
    public void MoveRight()
    {
        transform.RotateAround(sphereOne.transform.position, Vector3.right, sidewaysForce * Time.deltaTime);
    }

    public void MoveLeft()
    {
        transform.RotateAround(sphereOne.transform.position, Vector3.left, sidewaysForce * Time.deltaTime);
    }
}
