using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public Rigidbody rigidbody;

    [SerializeField]
    private float offset;

    [SerializeField]
    private LifeController lifeController;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "LeftCollider")
        {
            movement.enabled = false;
            movement.transform.Rotate(offset, 0, 0);
        }
        if (collision.tag == "RightCollider")
        {
            movement.enabled = false;
            movement.transform.Rotate(-offset, 0, 0);
        }
        if(collision.tag == "Hills") 
        {
            lifeController.TakeDamage();
        }
        if(collision.tag == "Meteor")
        {
            lifeController.TakeDamage();
        }
    }
    void OnTriggerExit(Collider collider)
    {
        movement.enabled = true;
    }

}
