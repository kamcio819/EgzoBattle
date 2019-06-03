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
    private PlayerMovement playerMovement;

    [HideInInspector]
    public static ControllerType controllerType = ControllerType.KEYBOARD;

    [SerializeField]
    private PlayerAnimationController playerAnimationController;

    private float valuePassedByLuna;
    private Action onUpdate = delegate { };

    private void OnEnable()
    {
        Lean.Touch.LeanTouch.OnFingerDown += (Lean.Touch.LeanFinger finger) => { onUpdate += MoveOnTouch; };
        Lean.Touch.LeanTouch.OnFingerUp += (Lean.Touch.LeanFinger finger) => { onUpdate -= MoveOnTouch; };
    }

    private void OnDisable()
    {
        Lean.Touch.LeanTouch.OnFingerDown -= (Lean.Touch.LeanFinger finger) => { onUpdate += MoveOnTouch; };
        Lean.Touch.LeanTouch.OnFingerUp -= (Lean.Touch.LeanFinger finger) => { onUpdate -= MoveOnTouch; };
    }

    private void FixedUpdate()
    {
        if (controllerType == ControllerType.KEYBOARD)
        {
            if (Input.GetKey(KeyCode.A))
            {
                playerMovement.MoveSimple(true);
                //playerMovement.DoAnimSimple(true);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                playerMovement.MoveSimple(false);
                //playerMovement.DoAnimSimple(false);
            }
        }

        onUpdate();


    }

    private void MoveOnTouch()
    {
        var finger = Lean.Touch.LeanTouch.Fingers[0];

        if (finger.ScreenPosition.x < Screen.width / 2)
        {
            playerMovement.MoveSimple(true);
        }
        else
        {
            playerMovement.MoveSimple(false);
        }
    }
}
