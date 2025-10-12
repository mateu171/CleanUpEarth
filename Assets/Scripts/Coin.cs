using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
     private GameObject target;
    [SerializeField] private float speed;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("CoinImage");    
    }
    private void Update()
    {
       transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);

        var dist = Vector3.Distance(transform.position, target.transform.position);

       if (dist < 0.1f)
       {
            Destroy(gameObject);
       }
    }
   
}
