using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : Singleton<MenuManager>
{
    private int gameDifficulty = 1;
    private ControllerType controllType = ControllerType.KEYBOARD;
    public int GameDifficulty { get => gameDifficulty; set => gameDifficulty = value; }
    public ControllerType ControllType { get => controllType; set => controllType = value; }

    protected override void Awake()
    {
        base.Awake();
    }
}
