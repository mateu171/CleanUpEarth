using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    public static GameObjectManager Instance { get; private set; }
    private List<GameObject> allGarbages = new List<GameObject>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void Register(GameObject garbage)
    {
        allGarbages.Add(garbage);
    }

    public void Unregister(GameObject garbage)
    {
        allGarbages.Remove(garbage);
    }

    public void DestroyAllGarbages()
    {
        foreach (GameObject gm in allGarbages)
            if (gm.activeInHierarchy)
            gm.SetActive(false);
    }
}
