using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField] private HeartSystemController heartSystemController;
    [SerializeField] private MeshFlashAnimator meshFlashAnimator;
    [SerializeField] private float invunerablilityTime;
    [SerializeField] private int maxHp;
    public int currentHp { private set { currentHp = value; } get { return heartSystemController.currentHP; } }
    private bool invunaerable = false;

    private void Awake()
    {
        heartSystemController.Initialize(maxHp);
        StartCoroutine(waitWhileInvunerable());
    }

    public void TakeDamage()
    {
        if (!invunaerable)
        {
            heartSystemController.DisableHeart();
            meshFlashAnimator.FlashMesh();
            StartCoroutine(waitWhileInvunerable());
        }
    }

    private IEnumerator waitWhileInvunerable()
    {
        invunaerable = true;
        yield return new WaitForSeconds(invunerablilityTime);
        invunaerable = false;
    }


}
