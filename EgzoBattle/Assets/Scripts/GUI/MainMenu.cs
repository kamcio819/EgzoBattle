using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int lvlType = 0;
    public void Play()
    {
        if (lvlType != 0)
        {
            SceneManager.LoadScene("SphereRunner");
        }
    }

    public void ChangeLevelDifficulty(int lvl)
    {
        lvlType = lvl;
        MenuManager.Instance.GameDifficulty = lvl;
    }

    public void ChangeLevelInput(int lvl)
    {
        if (lvl == 0)
            MenuManager.Instance.ControllType = ControllerType.LUNA;
        if (lvl == 1)
            MenuManager.Instance.ControllType = ControllerType.KEYBOARD;
    }

}