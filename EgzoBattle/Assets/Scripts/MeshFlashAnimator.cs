using UnityEngine;
using System.Collections;

public class MeshFlashAnimator : MonoBehaviour
{
    [SerializeField] private MeshFlashAnimarorData animatorData;
    [SerializeField] private MeshRenderer meshRenderer;
    private Coroutine flashProcess;

    public void FlashMesh()
    {
        if (flashProcess != null)
        {
            StopCoroutine(flashProcess);
        }

        flashProcess = StartCoroutine(flashMeshProcess(animatorData));
    }

    private IEnumerator flashMeshProcess(MeshFlashAnimarorData animatorData)
    {
        for (int i = 0; i < animatorData.numberOfTicks; ++i)
        {
            meshRenderer.enabled = false;
            yield return new WaitForSeconds(animatorData.disabledTickDuration);
            meshRenderer.enabled = true;
            yield return new WaitForSeconds(animatorData.enabledTickDuration);
        }
    }
}

[System.Serializable]
public struct MeshFlashAnimarorData
{
    public float numberOfTicks;
    public float enabledTickDuration;
    public float disabledTickDuration;
}