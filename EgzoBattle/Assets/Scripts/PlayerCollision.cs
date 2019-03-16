using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public Rigidbody rigidbody;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "LeftCollider") {
            movement.enabled=false;
            movement.transform.Rotate(1f, 0, 0);
        }
        if(collision.tag == "RightCollider") {
            movement.enabled=false;
            movement.transform.Rotate(-1f, 0, 0);
        }
    }
    void OnTriggerExit(Collider collider)
    {
        movement.enabled=true;
    }

}
