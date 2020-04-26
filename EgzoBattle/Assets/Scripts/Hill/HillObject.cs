using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillObject : EnemyObject
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HillUnlocker"))
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("HillUnlocker"))
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}