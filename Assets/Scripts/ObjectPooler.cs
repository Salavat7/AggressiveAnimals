using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private GameObject _objectToPool;
    [SerializeField] private int _amountToPool;
    public static ObjectPooler SharedInstance;
    private List<GameObject> _pooledObjects = new List<GameObject>();

    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        // Loop through list of pooled objects, deactivating them and adding them to the list 
        for (int i = 0; i < _amountToPool; i++)
        {
            GameObject obj = Instantiate(_objectToPool);//copy
            obj.SetActive(false);                       //deactivating
            _pooledObjects.Add(obj);                    //add to pool
            obj.transform.SetParent(this.transform);    //set as children of Spawn Manager
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < _pooledObjects.Count; i++)
        {
            // if pooled object is not active, return that object 
            if (!_pooledObjects[i].activeInHierarchy)
            {
                return _pooledObjects[i];
            }
        }
        // otherwise, return null   
        return null;
    }

}
