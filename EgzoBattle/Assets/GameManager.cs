using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
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
    }



}
