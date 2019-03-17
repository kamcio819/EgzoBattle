using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private RotateSphere rotateSphere;
    [SerializeField] TextMeshProUGUI counterText;
    private int counterPointsOnGUI;
    // Start is called before the first frame update
    void Start()
    {
        counterPointsOnGUI = 0;
    }

    // Update is called once per frame
    void Update()
    {
        counterPointsOnGUI++;
        counterText.text = counterPointsOnGUI.ToString();

        if(int.Parse(counterText.text) % 10000 == 0) {
            rotateSphere.speed *= 1.2f;
        }
    }



}
