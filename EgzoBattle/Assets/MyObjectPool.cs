using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

public class MyObjectPool : MonoBehaviour
{
    public List<GameObject> pooledObjects = new List<GameObject>();

    private GameObject pooledObj;
    private int idLayer;

    private int maxPoolSize;

    private int initialPoolSize;

    public void SetPool(GameObject obj, int initialPoolSize, int maxPoolSize, bool shouldBeNetworked, GameObject parrent)
    {
        pooledObjects = new List<GameObject>();
        idLayer = obj.layer;

        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject nObj;
            nObj = GameObject.Instantiate(obj, obj.transform.position, Quaternion.identity, parrent.transform) as GameObject;
            nObj.SetActive(true);
            pooledObjects.Add(nObj);
        }
        this.maxPoolSize = maxPoolSize;
        this.pooledObj = obj;
        this.initialPoolSize = initialPoolSize;
    }

    public GameObject GetObject(bool shouldActivateObject, GameObject parrent)
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (pooledObjects[i].activeSelf == false)
            {
                if (shouldActivateObject)
                {
                    pooledObjects[i].SetActive(true);
                }
                return pooledObjects[i];
            }
        }

        if (this.maxPoolSize > this.pooledObjects.Count)
        {
            GameObject nObj = GameObject.Instantiate(pooledObj, Vector3.zero, Quaternion.identity, parrent.transform) as GameObject;
            if (shouldActivateObject)
            {
                nObj.SetActive(true);
            }
            pooledObjects.Add(nObj);
            return nObj;
        }
        return null;
    }

    public void DisableAllObjects()
    {
        pooledObjects.ForEach(item => item.SetActive(false));
    }

    public int GetIDLayer()
    {
        return idLayer;
    }

    public void ClearObjects()
    {
        pooledObjects.Clear();
    }

   

}