using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody Rg;
    public float SidewayForce;

    [SerializeField]
    private ShipAnimationController shipAnimationController = default;

    public GameObject sphereOne;

    public void MoveLuna(float value)
    {
        if (value > 0)
        {
            transform.RotateAround(sphereOne.transform.position, Vector3.right, SidewayForce * value * Time.deltaTime);
        }
        else if (value < 0)
        {
            transform.RotateAround(sphereOne.transform.position, -Vector3.right, SidewayForce * (-1) * value * Time.deltaTime);
        }

    }

    public void MoveSimple(bool turn)
    {
        if (!turn)
        {
            transform.RotateAround(sphereOne.transform.position, Vector3.right, SidewayForce * Time.deltaTime);
        }
        else if (turn)
        {
            transform.RotateAround(sphereOne.transform.position, -Vector3.right, SidewayForce * Time.deltaTime);
        }

    }

    public void DoAnimLuna(float value)
    {
        shipAnimationController.RotateAnim(SidewayForce * value * Time.deltaTime);
    }

    public void DoAnimSimple(bool turn)
    {
        shipAnimationController.RotateAnimSimple(SidewayForce * Time.deltaTime, turn);
    }
}
