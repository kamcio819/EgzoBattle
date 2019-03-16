using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playerMovement;

    [SerializeField]
    private PlayerAnimationController playerAnimationController;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            playerMovement.MoveLeft();
            playerAnimationController.PlayLeftAnimation();
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerMovement.MoveRight();
            playerAnimationController.PlayRightAnimation();
        }
        else
        {
            playerAnimationController.StopAnimation();
        }
    }
}
