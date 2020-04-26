using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField]
    private MeteorSpawner meteorSpawner = default;

    [SerializeField]
    private HillsSpawner hillsSpawner = default;

    [SerializeField]
    private BoostersSpawner boostersSpawner = default;

    private void Start()
    {
        meteorSpawner.OnStart();
        hillsSpawner.OnStart();
        boostersSpawner.OnStart();
    }

    private void Update()
    {
        meteorSpawner.OnUpdate();
        hillsSpawner.OnUpdate();
        boostersSpawner.OnUpdate();
    }
}
