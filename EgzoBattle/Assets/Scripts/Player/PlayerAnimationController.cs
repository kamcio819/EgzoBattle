using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator animatorPlayer = default;

    public void PlayLeftAnimation()
    {
        animatorPlayer.SetTrigger("TurnLeft");
    }

    public void PlayRightAnimation()
    {
        animatorPlayer.SetTrigger("TurnRight");
    }
}
