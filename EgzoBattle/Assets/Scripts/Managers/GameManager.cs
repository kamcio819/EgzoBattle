using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private RotateSphere rotateSphere = default;

    [SerializeField] TextMeshProUGUI counterText = default;

    private int counterPointsOnGUI;

    private void Start()
    {
        counterPointsOnGUI = 0;
    }

    private void Update()
    {
        counterPointsOnGUI++;
        counterText.text = counterPointsOnGUI.ToString();

        if (int.Parse(counterText.text) % 10000 == 0)
        {
            rotateSphere.speed *= 1.2f;
        }
    }
}
