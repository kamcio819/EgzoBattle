using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameGUI : MonoBehaviour
{
    public void exit()
    {
        Debug.Log("Quit");
        SceneManager.LoadScene(0);

    }
}

