using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class PlayerMovement : MonoBehaviour
{
    public float sidewaysForce;
    [SerializeField]
    public GameObject sphereOne;
    [SerializeField] private float maxSidewaysMovementOffset;
    private float currentSidewaysMovementOffset;
    [SerializeField] private AnimationCurve spaceshipAnimation;
    [SerializeField] private ShipAnimationController shipAnimationController;
    [SerializeField] private Transform spaceshipModel;

    private Sequence idleAnimation;
    [SerializeField] private float currentSpaceshipPosition = 101.5f;

    public bool IsOnRotatingRight { get; set; }
    public bool IsOnRotatingLeft { get; set; }

    private void Awake()
    {
        SetUpIdleAnim();
        shipAnimationController.Init(StartIdleAinmIfNotBoostedUp, StopIdleAnim);
    }

    public void SetUpIdleAnim()
    {

        Tween goUp = spaceshipModel.DOLocalMoveY(currentSpaceshipPosition + 1, 1).SetEase(spaceshipAnimation);
        Tween goDown = spaceshipModel.DOLocalMoveY(currentSpaceshipPosition, 1).SetEase(spaceshipAnimation);

        Sequence doAnim = DOTween.Sequence();
        doAnim.Append(goUp);
        doAnim.Append(goDown);
        doAnim.SetLoops(-1, LoopType.Restart);
        idleAnimation = doAnim;
        StartIdleAinm();
    }


    public void MoveSimpleOnTouch(bool turn)
    {
        if (!turn)
        {
            transform.RotateAround(sphereOne.transform.position, Vector3.right, sidewaysForce * Time.deltaTime);
        }
        else if (turn)
        {
            transform.RotateAround(sphereOne.transform.position, -Vector3.right, sidewaysForce * Time.deltaTime);
        }
    }

    public void MoveSimpleOnGyro(bool turn, float x)
    {
        if (!turn)
        {
            if (currentSidewaysMovementOffset < maxSidewaysMovementOffset)
            {
                if (!IsOnRotatingRight)
                {
                    IsOnRotatingRight = true;
                    shipAnimationController.StartRotateRight();
                }

                float movedistance = sidewaysForce * Mathf.Abs(x) * Time.deltaTime;
                transform.RotateAround(sphereOne.transform.position, Vector3.right, movedistance);
                currentSidewaysMovementOffset = Mathf.Clamp(currentSidewaysMovementOffset + movedistance, -maxSidewaysMovementOffset, maxSidewaysMovementOffset);
            }
        }
        else if (turn)
        {
            if (currentSidewaysMovementOffset > -maxSidewaysMovementOffset)
            {

                if (!IsOnRotatingLeft)
                {
                    IsOnRotatingLeft = true;
                    shipAnimationController.StartRotateLeft();
                }

                float movedistance = sidewaysForce * Mathf.Abs(x) * Time.deltaTime;
                transform.RotateAround(sphereOne.transform.position, -Vector3.right, movedistance);
                currentSidewaysMovementOffset = Mathf.Clamp(currentSidewaysMovementOffset - movedistance, -maxSidewaysMovementOffset, maxSidewaysMovementOffset);

            }
        }

    }

    public void StartIdleAinm()
    {
        idleAnimation.Play();
    }

    public void StartIdleAinmIfNotBoostedUp()
    {
        if (!BoosterManager.isBoostedUp)
        {
            idleAnimation.Play();
        }
    }

    public void StopIdleAnim()
    {
        idleAnimation.Pause();
    }



    public void OnPotentialBackToOroginalRotation()
    {
        if (IsOnRotatingLeft || IsOnRotatingRight)
        {
            IsOnRotatingLeft = false;
            IsOnRotatingRight = false;
            shipAnimationController.StartRotateOriginal();
        }
    }
}
