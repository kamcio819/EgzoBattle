using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField]
    private MeteorSpawner meteorSpawner;

    [SerializeField]
    private HillsSpawner hillsSpawner; 

    [SerializeField]
    private BoostersSpawner boostersSpawner;
    private void Start() {
        meteorSpawner.OnStart();
        hillsSpawner.OnStart();
        boostersSpawner.OnStart();
    }
    private void Update() {
       meteorSpawner.OnUpdate();
       hillsSpawner.OnUpdate();
       boostersSpawner.OnUpdate();
    }   
}
