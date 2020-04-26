﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoosterManager : MonoBehaviour
{
    public RotateSphere rotateSphere;
    public int rotationSpeed;
    public float rotationTime;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "BoosterObstacle")
        {
            rotateSphere.speed = rotationSpeed;
        }
    }

    private void Update()
    {
        rotationTime -= Time.deltaTime;
        if (rotationTime < 0)
        {
            rotateSphere.speed = 5;
        }
    }
}
