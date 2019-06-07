using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float sidewaysForce;
    [SerializeField]
    private LUNAWebSocketConnection lUNAWebSocketConnection;

    [SerializeField]
    private ShipAnimationController shipAnimationController;

    public GameObject sphereOne;
    [SerializeField] private AnimationCurve spaceshipAnimation;
    [SerializeField] private Transform spaceshipModel;

    private Sequence idleAnimation;
    private void Awake()
    {
        SetUpIdleAnim();
    }

    public void MoveSimple(bool turn)
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
    public void DoAnimSimple(bool turn)
    {
        shipAnimationController.RotateAnimSimple(sidewaysForce * Time.deltaTime, turn);
    }

    public void SetUpIdleAnim()
    {
        float currentPosition = spaceshipModel.position.y;
        Tween goUp = spaceshipModel.DOMoveY(currentPosition + 1, 1).SetEase(spaceshipAnimation);
        Tween goDown = spaceshipModel.DOMoveY(currentPosition, 1).SetEase(spaceshipAnimation);

        Sequence doAnim = DOTween.Sequence();
        doAnim.Append(goUp);
        doAnim.Append(goDown);
        doAnim.SetLoops(-1, LoopType.Restart);
        idleAnimation = doAnim;
        StartIdleAinm();
    }

    public void StartIdleAinm()
    {
        idleAnimation.Play();
    }

    public void StopIdleAnim()
    {
        idleAnimation.Pause();
    }
}
