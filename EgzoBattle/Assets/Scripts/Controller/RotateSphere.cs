using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSphere : MonoBehaviour
{
    public float speed = 5f;
    private void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
