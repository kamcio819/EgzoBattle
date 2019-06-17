using UnityEngine;
using System;


public class DeathController : MonoBehaviour
{

    [SerializeField] private LifeController lifeController;
    [SerializeField] private FinalCanvasController finalCanvasController;

    private Action onUpdate = delegate { };

    private void Awake()
    {
        onUpdate += checkForDeath;

    }

    private void Update()
    {
        onUpdate();
    }


    private void checkForDeath()
    {
        if (lifeController.currentHp == 0)
        {
            finalCanvasController.Display();
            onUpdate -= checkForDeath;
        }
    }
}