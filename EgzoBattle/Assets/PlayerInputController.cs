using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playerMovement;

    [SerializeField]
    private PlayerAnimationController playerAnimationController;

    private float valuePassedByLuna;

    private void OnEnable() {
        LUNAWebSocketConnection.valueRecieved += OnUpdate;
    }

   private void OnUpdate(double obj)
   {
      valuePassedByLuna = (float)obj;
      Debug.Log(valuePassedByLuna);
   }

   private void FixedUpdate() {
      playerMovement.Move(valuePassedByLuna);
      playerMovement.DoAnim(valuePassedByLuna);
   }
}
