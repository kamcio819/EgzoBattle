using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwitcher : MonoBehaviour
{
    private void OnEnable() {
        var mats = GetComponent<Renderer>().materials;
        mats[0] = GameController.Instance.ChoosedMaterial;
        GetComponent<Renderer>().materials = mats;
    }
}
