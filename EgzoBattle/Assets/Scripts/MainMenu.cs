using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int lvlType = 0;
    public void playGame()
    {
        if(lvlType != 0) {
            SceneManager.LoadScene("SphereRunner");
        }
    }

    public void ChangeLevelDifficulty(int lvl) {
        lvlType = lvl;
        MenuManager.instance.GameDifficulty = lvl;
    }

    public void ChangeLevelInput(int lvl) {
        if(lvl == 0)
            MenuManager.instance.ControllType = ControllerType.LUNA;
        if(lvl == 1)
            MenuManager.instance.ControllType = ControllerType.KEYBOARD;
    }

}