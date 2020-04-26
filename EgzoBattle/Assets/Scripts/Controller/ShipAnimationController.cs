﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAnimationController : MonoBehaviour
{
    [SerializeField]
    private Transform animationTransformController = default;
    public void RotateAnimLeft(float value)
    {
        Quaternion quaternionToRotate = Quaternion.FromToRotation(animationTransformController.forward, -animationTransformController.right) * animationTransformController.rotation;

        animationTransformController.rotation = Quaternion.Slerp(animationTransformController.rotation, quaternionToRotate, 0.05f * value);
    }

    public void RotateAnimRight(float value)
    {
        Quaternion quaternionToRotate = Quaternion.FromToRotation(animationTransformController.forward, animationTransformController.right) * animationTransformController.rotation;

        animationTransformController.rotation = Quaternion.Slerp(animationTransformController.rotation, quaternionToRotate, 0.05f * value);
    }

    public void RotateAnim(float v)
    {
        if (v < 0)
        {
            RotateAnimLeft(v);
        }
        else if (v > 0)
        {
            RotateAnimRight(v);
        }

    }

    public void RotateAnimSimple(float value, bool turn)
    {
        if (turn)
        {
            RotateAnimLeft(value);
        }
        else if (!turn)
        {
            RotateAnimRight(value);
        }
    }
}
