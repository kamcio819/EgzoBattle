using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform m_player;
    public Vector3 offset;

    private void Update()
    {
        transform.position = m_player.transform.position + offset;
    }
}
