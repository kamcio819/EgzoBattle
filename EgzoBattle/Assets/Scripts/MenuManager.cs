using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private int gameDifficulty = 1;
    private ControllerType controllType = ControllerType.KEYBOARD;

    public static MenuManager instance = null;

   public int GameDifficulty { get => gameDifficulty; set => gameDifficulty = value; }
   public ControllerType ControllType { get => controllType; set => controllType = value; }

   private void Awake()
    {
        if (instance == null)
        {    
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);    
        
    }
}
