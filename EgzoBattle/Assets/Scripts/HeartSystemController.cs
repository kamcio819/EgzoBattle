using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSystemController : MonoBehaviour
{
    [SerializeField] private GameObject heartImagePrefab;
    private List<GameObject> hearts;
    private int maxHP = 0;
    private int currentHPIndex = 0;
    public int currentHP { get { return currentHPIndex + 1; } set { currentHP = value; } }


    public void Initialize(int _maxHP)
    {
        maxHP = _maxHP;
        currentHPIndex = _maxHP - 1;

        hearts = new List<GameObject>();

        for (int i = 0; i < _maxHP; ++i)
        {
            hearts.Add(Instantiate(heartImagePrefab, transform));
        }
    }

    public void DisableHeart()
    {
        if (currentHPIndex >= 0)
        {
            hearts[currentHPIndex].SetActive(false);
        }
        currentHPIndex--;
    }

    public void EnableHearts()
    {
        for (int i = 0; i < hearts.Count; ++i)
        {
            hearts[i].SetActive(true);
        }
        currentHPIndex = maxHP - 1;
    }
}
