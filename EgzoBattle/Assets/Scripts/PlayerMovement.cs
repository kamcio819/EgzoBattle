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
        shipAnimationController.Init(StartIdleAinm, StopIdleAnim);
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
            if (!IsOnRotatingRight)
            {
                IsOnRotatingRight = true;
                shipAnimationController.StartRotateRight();
            }
            transform.RotateAround(sphereOne.transform.position, Vector3.right, sidewaysForce * Mathf.Abs(x) * Time.deltaTime);

        }
        else if (turn)
        {
            if (!IsOnRotatingLeft)
            {
                IsOnRotatingLeft = true;
                shipAnimationController.StartRotateLeft();
            }
            transform.RotateAround(sphereOne.transform.position, -Vector3.right, sidewaysForce * Mathf.Abs(x) * Time.deltaTime);
        }

    }

    public void StartIdleAinm()
    {
        idleAnimation.Play();
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
