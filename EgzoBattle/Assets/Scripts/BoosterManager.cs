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

    bool isBoostedUp;

    public void AddForceToShipOverTime()
    {
        if (!isBoostedUp)
        {

            playerMovement.StopIdleAnim();

            float currentPosition = spaceShipModel.position.y;
            Tween goUp = spaceShipModel.DOMoveY(distanceToRaise, raisingTime).SetEase(boosterAnimation);
            Tween goDown = spaceShipModel.DOMoveY(currentPosition, raisingTime).SetEase(boosterAnimation);

            Sequence doRaise = DOTween.Sequence();
            doRaise.Append(goUp);
            doRaise.AppendInterval(timeInAir);
            doRaise.Append(goDown);
            doRaise.AppendCallback(onJumpComplete);
            doRaise.Play();
            isBoostedUp = true;
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
        isBoostedUp = false;
        playerMovement.StartIdleAinm();
    }
}
