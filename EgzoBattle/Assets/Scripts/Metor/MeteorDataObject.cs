using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorDataObject : ScriptableObject
{
    public GameObject ParticleSystem;
    public float MovementSpeed;
    public float RotationSpeed;
    public Material Material;
    public string Name;
}
