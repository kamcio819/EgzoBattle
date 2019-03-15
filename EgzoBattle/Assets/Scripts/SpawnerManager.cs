using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField]
    private MeteorSpawner meteorSpawner;

    [SerializeField]
    private HillsSpawner hillsSpawner; 

    private void Update() {
       meteorSpawner.OnUpdate();
       hillsSpawner.OnUpdate();
    }   
}
