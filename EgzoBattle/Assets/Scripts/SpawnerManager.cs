using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField]
    private MeteorSpawner meteorSpawner;

    [SerializeField]
    private HillsSpawner hillsSpawner; 

    private void Start() {
        meteorSpawner.OnStart();
        hillsSpawner.OnStart();
    }
    private void Update() {
       meteorSpawner.OnUpdate();
       hillsSpawner.OnUpdate();
    }   
}
