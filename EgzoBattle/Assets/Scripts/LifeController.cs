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
    private bool invunaerable = false;

    private void Awake()
    {
        heartSystemController.Initialize(maxHp);
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
