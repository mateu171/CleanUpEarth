using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoosts : MonoBehaviour
{
    [SerializeField] private List<GameObject> boostsList;
    [SerializeField] private float spawnWait;
    [SerializeField] private float minX, maxX;

    private void Start()
    {
        StartCoroutine(SpawnGarbage());
    }
    private IEnumerator SpawnGarbage()
    {
        yield return new WaitForSeconds(spawnWait);

        while (true)
        {
                int randomIndex = Random.Range(0, boostsList.Count);
                Instantiate(boostsList[randomIndex], GetRandomSpawnPosition(), gameObject.transform.rotation);

                yield return new WaitForSeconds(spawnWait);
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        return new Vector3(Random.Range(minX, maxX), transform.position.y, transform.position.z);
    }
}
