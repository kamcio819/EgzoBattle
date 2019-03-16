using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAnimationController : MonoBehaviour
{
    public void RotateAnimLeft(float value) {
        Quaternion quaternionToRotate = Quaternion.FromToRotation(gameObject.transform.forward, -gameObject.transform.right) * gameObject.transform.rotation;

   
       gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, quaternionToRotate, 0.015f);
    }

    public void RotateAnimRight(float value) {
        Quaternion quaternionToRotate = Quaternion.FromToRotation(gameObject.transform.forward, gameObject.transform.right) * gameObject.transform.rotation;

       gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, quaternionToRotate, 0.015f);
    }
}
