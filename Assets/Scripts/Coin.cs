using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameObject target;
    [SerializeField] private float speed;
    private const float checkOnDestroy = 0.1f;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("CoinImage");
    }

    private void Update()
    {
       transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        var dist = Vector3.Distance(transform.position, target.transform.position);

       if (dist < checkOnDestroy)
       {
            Destroy(gameObject);
       }
    }
   
}
