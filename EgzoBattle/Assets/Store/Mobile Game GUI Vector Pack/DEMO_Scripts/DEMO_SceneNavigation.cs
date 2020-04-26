using UnityEngine;

public class DEMO_SceneNavigation : MonoBehaviour
{
    [SerializeField]
    private GameObject graphicsManager = default;
    [SerializeField]
    private GameObject soundManager = default;

    public void ChangeWindows(string nameBt)
    {
        soundManager.GetComponent<DEMO_SoundManager>().PlayClickSound();
        switch (nameBt)
        {
            case "ViewUpdateBt":
                graphicsManager.GetComponent<DEMO_GraphicsManager>().EnableUpdate_1_View(true);
                graphicsManager.GetComponent<DEMO_GraphicsManager>().GetCurrentScene();
                break;
            case "Prev":
                graphicsManager.GetComponent<DEMO_GraphicsManager>().GetPrevScene();
                break;
            case "Next":
                graphicsManager.GetComponent<DEMO_GraphicsManager>().GetNextScene();
                break;
            default:
                break;
        }

    }
}
