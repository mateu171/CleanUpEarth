using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> garbageList;
    [SerializeField] private float spawnWait;
    [SerializeField] private float minX,maxX;
    [SerializeField] private float waveWait;
    [SerializeField] private int countSpawn;

    private void Start()
    {
        StartCoroutine(SpawnGarbage());
    }
    private IEnumerator SpawnGarbage()
    {
        while (true)
        {
            for (int i = 0; i < countSpawn; i++)
            {
                int randomIndex = Random.Range(0, garbageList.Count);
                Instantiate(garbageList[randomIndex], GetRandomSpawnPosition(), gameObject.transform.rotation);

                yield return new WaitForSeconds(Random.Range(0.5f, spawnWait));
            }

            countSpawn++;
            Debug.Log(countSpawn);
            yield return new WaitForSeconds(waveWait);
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        return new Vector3(Random.Range(minX, maxX), transform.position.y, transform.position.z);
    }
}
