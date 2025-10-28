using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolForGarbage<T> where T : MonoBehaviour
{
    private T _prefab;
    private Transform _parent;
    private List<T> _objects;

    public PoolForGarbage(T prefab,Transform parent, int prewarmObjcets)
    {
        _prefab = prefab;
        _parent = parent;
        _objects = new List<T>();
       
        for (int i = 0; i < prewarmObjcets; i++)
        {
            var obj = Create();
            obj.gameObject.SetActive(false);         
        }      
    }

    public T Get()
    {
        var obj = _objects.FirstOrDefault(x => !x.gameObject.activeInHierarchy);

        if (obj == null)
        {
            obj = Create();
        }

        obj.gameObject.SetActive(true);
        return obj;
    }

    public void Release(T obj)
    {
        obj.gameObject.SetActive(false);
    }
    private T Create()
    {
        var obj = GameObject.Instantiate(_prefab);
        _objects.Add(obj);
        return obj;
    }

    public void ReleaseAll()
    {
        foreach (var obj in _objects)
            obj.gameObject.SetActive(false);
    }
}
