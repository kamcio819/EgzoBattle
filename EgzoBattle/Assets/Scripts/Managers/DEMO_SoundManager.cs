using UnityEngine;

public class DEMO_SoundManager : MonoBehaviour
{
    public void PlayClickSound()
    {
        this.GetComponent<AudioSource>().Play();
    }
}
