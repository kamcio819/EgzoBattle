using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class BoosterManager : MonoBehaviour
{
    [SerializeField] private AnimationCurve boosterAnimation;
    [SerializeField] private Transform spaceShipModel;
    [SerializeField] private PlayerMovement playerMovement;

    [Header("Speed Booster")]

    [SerializeField] private RotateSphere sphere;
    [SerializeField] private float speedGivenByBooster;
    [SerializeField] private float timeInHigherSpeed;

    [Header("Up Booster")]

    //[SerializeField] GameObject spaceShipModel;
    [SerializeField] private float timeInAir;
    [SerializeField] private float raisingTime;
    [SerializeField] private float distanceToRaise = 110f;
    [SerializeField] private float currentSpaceshipPosition = 101.5f;

    public static bool isBoostedUp;
    Sequence upBoosterAnim;

    public void AddForceToShipOverTime()
    {
        if (!BoosterManager.isBoostedUp)
        {

            playerMovement.StopIdleAnim();
            SetUpBoosterUpAnim(upBoosterAnim);
            upBoosterAnim.Play();
            BoosterManager.isBoostedUp = true;
        }
    }
    public IEnumerator AddSpeedToShipOverTime()
    {
        float currentSphereRotationSpeed = sphere.speed;
        sphere.speed = speedGivenByBooster;
        yield return new WaitForSeconds(timeInHigherSpeed);
        sphere.speed = currentSphereRotationSpeed;
    }


    private void onJumpComplete()
    {
        BoosterManager.isBoostedUp = false;
        playerMovement.StartIdleAinm();
    }

    private void SetUpBoosterUpAnim(Sequence upAnim)
    {
        Tween goUp = spaceShipModel.DOLocalMoveY(distanceToRaise, raisingTime).SetEase(boosterAnimation);
        Tween goDown = spaceShipModel.DOLocalMoveY(currentSpaceshipPosition, raisingTime).SetEase(boosterAnimation);

        upAnim = DOTween.Sequence();
        upAnim.Append(goUp);
        upAnim.AppendInterval(timeInAir);
        upAnim.Append(goDown);
        upAnim.AppendCallback(onJumpComplete);
    }
}
