using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;

    [SerializeField]
    private BoosterManager boosterManager;

    [SerializeField]
    private float offset;

    [SerializeField]
    private LifeController lifeController;


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
        if (collision.tag == "Hills")
        {
            lifeController.TakeDamage();
        }
        if (collision.tag == "Meteor")
        {
            lifeController.TakeDamage();
        }
        if (collision.tag == "BoosterObstacle")
        {
            Debug.Log("boosteobstacle");
            StartCoroutine(boosterManager.AddSpeedToShipOverTime());
        }

        if (collision.tag == "RaiseObstacle")
        {
            boosterManager.AddForceToShipOverTime();

        }
    }
    void OnTriggerExit(Collider collider)
    {
        movement.enabled = true;
    }


}
