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
    [SerializeField]
    private ShipAnimationController shipAnimationController;

    [HideInInspector]
    public static ControllerType controllerType = ControllerType.KEYBOARD;

    [SerializeField] float movementTreshold = 0.2f;
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
        MoveOnGryo();
        //onUpdate();
    }

    private void MoveOnTouch()
    {
        var finger = Lean.Touch.LeanTouch.Fingers[0];

        if (finger.ScreenPosition.x < Screen.width / 2)
        {
            playerMovement.MoveSimpleOnTouch(true);
        }
        else
        {
            playerMovement.MoveSimpleOnTouch(false);
        }
    }

    private void MoveOnGryo()
    {
        if (Input.acceleration.x < -movementTreshold)
        {
            playerMovement.MoveSimpleOnGyro(true, Input.acceleration.x);

        }
        else if (Input.acceleration.x > movementTreshold)
        {
            playerMovement.MoveSimpleOnGyro(false, Input.acceleration.x);
        }
        else
        {
            playerMovement.OnPotentialBackToOroginalRotation();
        }

    }


}
