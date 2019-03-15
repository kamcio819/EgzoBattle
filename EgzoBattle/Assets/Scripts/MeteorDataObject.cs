using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorDataObject : ScriptableObject
{
    public ParticleSystem particleSystem;
    public float meteorMovementSpeed;
    public float meteorRotationSpeed;
    public Material meteorMaterial;
    public string name;
}
