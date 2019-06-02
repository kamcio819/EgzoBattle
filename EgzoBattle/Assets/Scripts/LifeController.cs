using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer meshRenderer;

    [SerializeField]
    private HeartSystemController heartSystemController;

    public void TakeDamage() {
        heartSystemController.DisableHeart();
        StartCoroutine(FlashMesh());
    }

   private IEnumerator FlashMesh()
   {
      meshRenderer.enabled = !meshRenderer.enabled;
      yield return new WaitForSeconds(0.1f);
      meshRenderer.enabled = !meshRenderer.enabled;
      yield return new WaitForSeconds(0.1f);
      meshRenderer.enabled = !meshRenderer.enabled;
      yield return new WaitForSeconds(0.1f);
      meshRenderer.enabled = !meshRenderer.enabled;
      yield return new WaitForSeconds(0.15f);
      meshRenderer.enabled = !meshRenderer.enabled;
      yield return new WaitForSeconds(0.15f);
      meshRenderer.enabled = !meshRenderer.enabled;
      yield return new WaitForSeconds(0.15f);
   }

    

}
