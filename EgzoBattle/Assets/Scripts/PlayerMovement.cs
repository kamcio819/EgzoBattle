using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class PlayerMovement : MonoBehaviour
{
    public float sidewaysForce;
    [SerializeField]
    private LUNAWebSocketConnection lUNAWebSocketConnection;

    [SerializeField]
    private ShipAnimationController shipAnimationController;

    public GameObject sphereOne;
    [SerializeField] private AnimationCurve spaceshipAnimation;
    [SerializeField] private Transform spaceshipModel;

    private Sequence idleAnimation;
    [SerializeField] private float currentSpaceshipPosition = 101.5f;
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

        Tween goUp = spaceshipModel.DOLocalMoveY(currentSpaceshipPosition + 1, 1).SetEase(spaceshipAnimation);
        Tween goDown = spaceshipModel.DOLocalMoveY(currentSpaceshipPosition, 1).SetEase(spaceshipAnimation);

        Sequence doAnim = DOTween.Sequence();
        doAnim.Append(goUp);
        doAnim.Append(goDown);
        doAnim.SetLoops(-1, LoopType.Restart);
        idleAnimation = doAnim;
        StartIdleAinm();
    }

    public void StartIdleAinm()
    {
        Debug.Log("xDD");
        idleAnimation.Play();
    }

    public void StopIdleAnim()
    {
        idleAnimation.Pause();
    }
}
