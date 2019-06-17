using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class fpscounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textObject;

    // Update is called once per frame
    void Update()
    {
        float tpsCount = 1 / Time.deltaTime;
        textObject.text = "FPS: " + tpsCount;
    }
}
