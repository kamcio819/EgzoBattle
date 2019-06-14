using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ShipAnimationController : MonoBehaviour
{
    [SerializeField] private Transform spaceShip;
    [SerializeField] private float maxRotateRight;
    [SerializeField] private float maxRotateLeft;
    private float defaultRotation = 0;

    [SerializeField] private int maxDuration;
    Tween rotateLeft;
    Tween rotateRight;
    Tween rotateToOriginal;

    private Action onStartIdle = delegate { };
    private Action onEndIdle = delegate { };

    public void Init(Action onStartIdle, Action onEndIdle)
    {
        this.onStartIdle = onStartIdle;
        this.onEndIdle = onEndIdle;
    }

    public void StartRotateLeft()
    {
        onEndIdle();
        KillCurentlyWorkingTweens();
        rotateLeft = spaceShip.DOLocalRotate(new Vector3(maxRotateLeft, 0, 0), GetDuration(maxRotateLeft), RotateMode.Fast);

    }
    public void StartRotateRight()
    {
        onEndIdle();
        KillCurentlyWorkingTweens();
        rotateRight = spaceShip.DOLocalRotate(new Vector3(maxRotateRight, 0, 0), GetDuration(maxRotateRight), RotateMode.Fast);

    }
    public void StartRotateOriginal()
    {

        KillCurentlyWorkingTweens();
        rotateToOriginal = spaceShip.DOLocalRotate(new Vector3(defaultRotation, 0, 0), GetDuration(defaultRotation), RotateMode.Fast).OnComplete(() => { onStartIdle(); });
    }
    public float GetDuration(float maxRotation)
    {

        float currentRotation = spaceShip.localRotation.eulerAngles.x;
        float rotationToMaxRotation = Mathf.Abs(maxRotation - currentRotation);

        Debug.Log(rotationToMaxRotation);
        if (rotationToMaxRotation > 180)
        {
            rotationToMaxRotation = 360 - rotationToMaxRotation;
        }

        float duration = (rotationToMaxRotation / 180) * maxDuration;
        return duration;
    }

    public void KillCurentlyWorkingTweens()
    {
        if (rotateLeft != null)
        {
            rotateLeft.Kill();
        }
        if (rotateRight != null)
        {
            rotateRight.Kill();
        }
        if (rotateToOriginal != null)
        {
            rotateToOriginal.Kill();
        }
    }


}
