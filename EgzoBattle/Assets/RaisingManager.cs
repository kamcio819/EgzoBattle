using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaisingManager : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    public PlayerMovement playerMovement;
    public Rigidbody rigidbody;

    public float jumpTime;
    public float forceCoeff;
    public float raisingTime;
    public float holdTime;
    void Update()
    {
        
    }
    IEnumerator RaisingCoroutine(Collider collision)
    {
            yield return new WaitForSeconds(jumpTime);
            animator.enabled = false;
            rigidbody.AddForce(rigidbody.transform.forward * forceCoeff);
            yield return new WaitForSeconds(raisingTime);
            rigidbody.AddForce(-rigidbody.transform.forward * forceCoeff);
            yield return new WaitForSeconds(holdTime);
            rigidbody.AddForce(-rigidbody.transform.forward * forceCoeff);
            yield return new WaitForSeconds(raisingTime);
            animator.enabled = true;

    }
    void OnTriggerEnter(Collider collision)
    {
         if (collision.tag == "RaiseObstacle")
        {
           StartCoroutine(RaisingCoroutine(collision));
        }
    }
}
