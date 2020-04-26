using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class MyObjectPoolManager : Singleton<MyObjectPoolManager>
{
    [SerializeField]
    private GameObject hillsParrent = default;

    [SerializeField]
    private GameObject meteorParrent = default;

    [SerializeField]
    private GameObject boostersParrent = default;

    private Dictionary<String, MyObjectPool> objectPools = new Dictionary<String, MyObjectPool>();

    protected override void Awake()
    {
        base.Awake();
    }

    public bool CreatePoolIfNotExists(GameObject objToPool, int initialPoolSize, int maxPoolSize, bool shouldBeNetworked)
    {
        if (IsAlreadyHavingPoolOfThisObject(objToPool))
        {
            return false;
        }
        else
        {
            CreateNewPool(objToPool, initialPoolSize, maxPoolSize, shouldBeNetworked);
            return true;
        }
    }

    private bool IsAlreadyHavingPoolOfThisObject(GameObject poolObject)
    {
        return objectPools.ContainsKey(poolObject.name);
    }

    private void CreateNewPool(GameObject objToPool, int initialPoolSize, int maxPoolSize, bool shouldBeNetworked)
    {
        MyObjectPool nPool;

        nPool = new MyObjectPool();

        if (objToPool.CompareTag("Hills"))
        {
            nPool.SetPool(objToPool, initialPoolSize, maxPoolSize, shouldBeNetworked, hillsParrent);
        }
        else if (objToPool.CompareTag("Meteor"))
        {
            nPool.SetPool(objToPool, initialPoolSize, maxPoolSize, shouldBeNetworked, meteorParrent);
        }
        else if (objToPool.CompareTag("RaiseObstacle"))
        {
            nPool.SetPool(objToPool, initialPoolSize, maxPoolSize, shouldBeNetworked, boostersParrent);
        }
        else if (objToPool.CompareTag("RaiseObstacle"))
        {
            nPool.SetPool(objToPool, initialPoolSize, maxPoolSize, shouldBeNetworked, boostersParrent);
        }
        objectPools.Add(objToPool.name, nPool);
    }

    public List<GameObject> GetAllPool(string name)
    {
        return objectPools[name].pooledObjects;
    }

    public GameObject GetObject(GameObject objName, bool shouldActvateObject)
    {
        if (objName.GetComponent<HillObject>() != null)
        {
            return MyObjectPoolManager.Instance.objectPools[objName.transform.name].GetObject(shouldActvateObject, hillsParrent);
        }
        else if (objName.GetComponent<MeteorObject>() != null)
        {
            return MyObjectPoolManager.Instance.objectPools[objName.transform.name].GetObject(shouldActvateObject, meteorParrent);
        }
        else return null;
    }

    public void DisableObejctsFromPool(int layer)
    {
        List<MyObjectPool> listAllPool = MyObjectPoolManager.Instance.objectPools.Values.ToList();

        foreach (MyObjectPool pool in listAllPool)
        {
            if (pool.GetIDLayer() == layer)
                pool.DisableAllObjects();
        }
    }

    public void ClearAllPoolObjects()
    {
        List<MyObjectPool> listAllPool = MyObjectPoolManager.Instance.objectPools.Values.ToList();
        {
            foreach (MyObjectPool pool in listAllPool)
            {
                pool.ClearObjects();
            }
        }

        MyObjectPoolManager.Instance.objectPools.Clear();

    }
}