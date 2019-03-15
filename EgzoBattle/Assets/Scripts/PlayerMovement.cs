using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rigidbody;
    public float sidewaysForce;
    [SerializeField]
    private LUNAWebSocketConnection lUNAWebSocketConnection;
    void Start()
    {
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("a")) {
            rigidbody.AddForce(-sidewaysForce * Time.deltaTime * Mathf.Abs((float)lUNAWebSocketConnection.lunaData.value),
            0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("d")) {
            rigidbody.AddForce(sidewaysForce * Time.deltaTime * Mathf.Abs((float)lUNAWebSocketConnection.lunaData.value),
            0, 0, ForceMode.VelocityChange);
        }
    }
}
