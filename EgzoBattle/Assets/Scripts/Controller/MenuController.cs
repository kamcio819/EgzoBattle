using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private List<Material> planetMaterials = default;

    public void SetMaterial(int index)
    {
        GameController.Instance.ChoosedMaterial = planetMaterials[index];
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
