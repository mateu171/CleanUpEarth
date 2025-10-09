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
            Vector3 lastPositon = gameObject.transform.position;
            gameObject.transform.position = new Vector3(Random.Range(-8, 8), transform.position.y, transform.position.z);

            if (lastPositon != gameObject.transform.position)
            {
                lastPositon = gameObject.transform.position;
                int randomIndex = Random.Range(0, garbages.Count);
                Instantiate(garbages[randomIndex], gameObject.transform.position, gameObject.transform.rotation);

                yield return new WaitForSeconds(delay);

            }
        }
    }
}
