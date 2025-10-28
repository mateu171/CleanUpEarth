using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoosts : MonoBehaviour
{
    [SerializeField] private List<GameObject> boostsList;
    [SerializeField] private float spawnWait;
    [SerializeField] private float minX, maxX;

    private List<PoolForGarbage<GameEntity>> _pools;
    private void Start()
    {
        _pools = new List<PoolForGarbage<GameEntity>>();

        foreach(var bt in boostsList)
        {
          var pool = new PoolForGarbage<GameEntity>(bt.GetComponent<GameEntity>(),transform,2);
            _pools.Add(pool);
        }

        StartCoroutine(SpawnBoost());
    }
    private IEnumerator SpawnBoost()
    {
        yield return new WaitForSeconds(spawnWait);

        while (true)
        {
            int randomIndex = Random.Range(0, boostsList.Count);
            var pool = _pools[randomIndex];
            var boost = pool.Get();
            boost.transform.position = GetRandomSpawnPosition();
            boost.SetPool(pool);
              
            yield return new WaitForSeconds(spawnWait);
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        return new Vector3(Random.Range(minX, maxX), transform.position.y, transform.position.z);
    }
}
