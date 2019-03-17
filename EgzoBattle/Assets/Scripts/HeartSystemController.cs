using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSystemController : MonoBehaviour
{
    [SerializeField]
    private Image[] heartsImages;
    
    private int index = 0;

    public void DisableHeart() {
        heartsImages[index].gameObject.SetActive(false);
        index++;
        index %= 3;
    }

    public void EnableHearts() {
        for(int i = 0; i < heartsImages.Length; ++i) {
            heartsImages[i].gameObject.SetActive(true);
        }
    }
}
