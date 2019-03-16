using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAnimationController : MonoBehaviour
{
    [SerializeField]
    private Transform animationTransformController;
    public void RotateAnimLeft(float value) {
        Quaternion quaternionToRotate = Quaternion.FromToRotation(animationTransformController.forward, -animationTransformController.right) * animationTransformController.rotation;
   
       animationTransformController.rotation = Quaternion.Slerp(animationTransformController.rotation, quaternionToRotate, 0.03f * value * (-1));
    }

    public void RotateAnimRight(float value) {
        Quaternion quaternionToRotate = Quaternion.FromToRotation(animationTransformController.forward, animationTransformController.right) * animationTransformController.rotation;

       animationTransformController.rotation = Quaternion.Slerp(animationTransformController.rotation, quaternionToRotate, 0.03f * value);
    }

   internal void RotateAnim(float v)
   {
       if(v < 0) {
           RotateAnimLeft(v);
       }
       else if( v > 0) {
           RotateAnimRight(v);
       }
         
    }
}
