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
    void Start()
    {
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("a")) {
            transform.RotateAround(sphereOne.transform.position, Vector3.left, sidewaysForce * Time.deltaTime);
        }
        if (Input.GetKey("d")) {
            transform.RotateAround(sphereOne.transform.position, Vector3.right, sidewaysForce * Time.deltaTime);
        }
    }
}
