using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    [SerializeField]
    private Material choosedMaterial;
    public Material ChoosedMaterial { get => choosedMaterial; set => choosedMaterial = value; }
}
