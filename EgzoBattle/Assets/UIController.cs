using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> menuScreens;

    public void OpenScreen(string screenName) {
        menuScreens.ForEach(x => x.SetActive(false));
        var screenToOpen = menuScreens.Find(x => x.name == screenName);
        screenToOpen.SetActive(true);
    }
}
