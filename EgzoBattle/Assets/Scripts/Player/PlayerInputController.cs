using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ControllerType
{
    LUNA,
    KEYBOARD
}
public class PlayerInputController : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playerMovement = default;

    public static ControllerType controllerType = ControllerType.KEYBOARD;

    private float valuePassedByLuna;

    private void OnEnable()
    {
        if (controllerType == ControllerType.LUNA)
            LUNAWebSocketConnection.valueRecieved += OnUpdate;
    }

    private void OnUpdate(double obj)
    {
        if (controllerType == ControllerType.LUNA)
        {
            LUNAWebSocketConnection.valueRecieved += OnUpdate;
            valuePassedByLuna = (float)obj;
            Debug.Log(valuePassedByLuna);
        }

    }
    private void FixedUpdate()
    {
        if (controllerType == ControllerType.LUNA)
        {
            playerMovement.MoveLuna(valuePassedByLuna);
            playerMovement.DoAnimLuna(valuePassedByLuna);
        }
        else if (controllerType == ControllerType.KEYBOARD)
        {
            if (Input.GetKey(KeyCode.A))
            {
                playerMovement.MoveSimple(true);
                playerMovement.DoAnimSimple(true);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                playerMovement.MoveSimple(false);
                playerMovement.DoAnimSimple(false);
            }
        }


    }
}
