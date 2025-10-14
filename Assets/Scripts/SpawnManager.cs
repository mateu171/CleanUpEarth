using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> garbageList;
    [SerializeField] private float delay;
    [SerializeField] private float minX,maxX;

    private void Start()
    {
        StartCoroutine(SpawnGarbage());
    }
    private IEnumerator SpawnGarbage()
    {
        while (true)
        {
            Vector3 lastPositon = gameObject.transform.position;
            var currentPosition = GetRandomSpawnPosition();

            if (lastPositon != currentPosition)
            {
                lastPositon = currentPosition;
                int randomIndex = Random.Range(0, garbageList.Count);
                Instantiate(garbageList[randomIndex], currentPosition, gameObject.transform.rotation);

                yield return new WaitForSeconds(delay);

            }
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        return new Vector3(Random.Range(minX, maxX), transform.position.y, transform.position.z);
    }
}
