using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int easyLvl = 0;
    private int normalLvl = 0;
    private int hardLvl = 0;
    public void playGame()
    {
        if (Equals(easyLvl, 1) || Equals(normalLvl, 2) || Equals(hardLvl, 3))
        {
            SceneManager.LoadScene(1);
        }
    }
    public void easyButtonOnClick()
    {
        easyLvl = 1;
    }
    public void normalButtonOnClick()
    {
        normalLvl = 2;
    }
    public void hardButtonOnClick()
    {
        hardLvl = 3;
    }


}