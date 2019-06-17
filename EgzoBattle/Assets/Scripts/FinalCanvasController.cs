using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FinalCanvasController : MonoBehaviour
{
    [SerializeField] private GameObject parentCanvas;
    [SerializeField] private TextMeshProUGUI textObject;
    [SerializeField] private GameManager gameManager;
    private string scoretext = "<color=#FFF800> You finished the game with score of <color=#ffffff> {0} <color=#FFF800> points.";

    private Action onUpdate = delegate { };

    private void OnEnable()
    {
        Lean.Touch.LeanTouch.OnFingerDown += (Lean.Touch.LeanFinger finger) => { onUpdate += returnTotitleScreen; };
    }

    private void OnDisable()
    {
        Lean.Touch.LeanTouch.OnFingerDown -= (Lean.Touch.LeanFinger finger) => { onUpdate += returnTotitleScreen; };
    }

    public void Display()
    {
        textObject.text = string.Format(scoretext, gameManager.counterPointsOnGUI);
        gameManager.DisableCounter();
        parentCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    private void returnTotitleScreen()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        onUpdate();
    }
}