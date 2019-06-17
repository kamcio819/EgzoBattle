using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private RotateSphere rotateSphere;
    [SerializeField] TextMeshProUGUI counterText;
    public float counterPointsOnGUI;
    // Start is called before the first frame update
    void Awake()
    {
        counterText.enabled = true;
        counterPointsOnGUI = 0;
    }

    // Update is called once per frame
    void Update()
    {
        counterPointsOnGUI += Time.deltaTime * 100f;
        counterText.text = ((int)counterPointsOnGUI).ToString();

        if (int.Parse(counterText.text) % 10000 == 0)
        {
            rotateSphere.speed *= 1.2f;
        }
    }

    public void DisableCounter()
    {
        counterText.enabled = false;
    }
}
