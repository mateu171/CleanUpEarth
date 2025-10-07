using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> garbages;
    [SerializeField] private float delay;

    private void Start()
    {
        StartCoroutine(SpawnGarbage());
    }
    private IEnumerator SpawnGarbage()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, garbages.Count);
            Instantiate(garbages[randomIndex],gameObject.transform.position,gameObject.transform.rotation);
            gameObject.transform.position = new Vector3(Random.Range(-8, 8), transform.position.y, transform.position.z);

            yield return new WaitForSeconds(delay);
        }
    }
}
