using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement PlayerMovement;
    public Rigidbody Rg;

    [SerializeField]
    private float offset = 0;

    [SerializeField]
    private LifeController lifeController = default;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "LeftCollider")
        {
            PlayerMovement.enabled = false;
            PlayerMovement.transform.Rotate(offset, 0, 0);
        }
        if (collision.tag == "RightCollider")
        {
            PlayerMovement.enabled = false;
            PlayerMovement.transform.Rotate(-offset, 0, 0);
        }
        if (collision.tag == "Hills")
        {
            lifeController.TakeDamage();
        }
        if (collision.tag == "Meteor")
        {
            lifeController.TakeDamage();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        PlayerMovement.enabled = true;
    }

}
