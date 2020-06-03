using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer meshRenderer = default;

    [SerializeField]
    private HeartSystemController heartSystemController  = default;

    public void TakeDamage()
    {
        heartSystemController.DisableHeart();
        StartCoroutine(FlashMesh());
    }

    private IEnumerator FlashMesh()
    {
        for (int i = 0; i < 5; ++i)
        {
            meshRenderer.enabled = !meshRenderer.enabled;
            yield return new WaitForSeconds(0.1f);
        }
        meshRenderer.enabled = true;
    }
}
