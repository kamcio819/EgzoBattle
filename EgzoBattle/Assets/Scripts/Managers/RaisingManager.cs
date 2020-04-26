using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaisingManager : MonoBehaviour
{
    [SerializeField]
    private Animator animator = default;

    public PlayerMovement PlayerMovement;
    public Rigidbody Rg;

    public float jumpTime;
    public float forceCoeff;
    public float raisingTime;
    public float holdTime;

    private IEnumerator RaisingCoroutine(Collider collision)
    {
        yield return new WaitForSeconds(jumpTime);
        animator.enabled = false;
        Rg.AddForce(Rg.transform.forward * forceCoeff);
        yield return new WaitForSeconds(raisingTime);
        Rg.AddForce(-Rg.transform.forward * forceCoeff);
        yield return new WaitForSeconds(holdTime);
        Rg.AddForce(-Rg.transform.forward * forceCoeff);
        yield return new WaitForSeconds(raisingTime);
        animator.enabled = true;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "RaiseObstacle")
        {
            StartCoroutine(RaisingCoroutine(collision));
        }
    }
}
