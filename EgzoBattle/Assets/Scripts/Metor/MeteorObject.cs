using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorObject : EnemyObject
{
    [SerializeField]
    private ParticleSystem destroyParticleSystem = default;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Planet"))
        {
            StartCoroutine(PlayDestroyParticleSystem());
        }
    }

    private IEnumerator PlayDestroyParticleSystem()
    {
        destroyParticleSystem.Play();

        yield return new WaitForSeconds(0.2f);

        gameObject.SetActive(false);
    }
}
