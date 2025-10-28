using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGarbages : MonoBehaviour
{
    [SerializeField] private List<GameObject> garbageList;
    [SerializeField] private float spawnWait;
    [SerializeField] private float minX,maxX;
    [SerializeField] private float waveWait;
    [SerializeField] private int countSpawn;

    private List<PoolForGarbage<Garbage>> _pools;
    private void Start()
    {
        _pools = new List<PoolForGarbage<Garbage>>();

        foreach(var gr in garbageList)
        {
            var pool = new PoolForGarbage<Garbage>(gr.GetComponent<Garbage>(), transform,2);
            _pools.Add(pool);
        }
        StartCoroutine(SpawnGarbage());
    }
    private IEnumerator SpawnGarbage()
    {

        while (true)
        {
            for (int i = 0; i < countSpawn; i++)
            {
                int randomIndex = Random.Range(0, _pools.Count);
                var pool = _pools[randomIndex];
                var garbage = pool.Get();
                garbage.transform.position = GetRandomSpawnPosition();
                garbage.SetPool(pool);


                yield return new WaitForSeconds(Random.Range(0.5f, spawnWait));
            }

            countSpawn++;
            yield return new WaitForSeconds(waveWait);
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        return new Vector3(Random.Range(minX, maxX), transform.position.y, transform.position.z);
    }
}
