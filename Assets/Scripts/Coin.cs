using System;
using System.Collections;
using UnityEngine;

public class Coin : GameEntity
{
    private GameObject target;
    [SerializeField] private float speed;

    private const float checkOnDestroy = 0.1f;
    private AudioSource _audioSource;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("CoinImage");
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(MoveCoinToTarget());
    }

    private IEnumerator MoveCoinToTarget()
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);

        while (dist > checkOnDestroy)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

            dist = Vector3.Distance(transform.position, target.transform.position);
            yield return null;
        }
        DestroyCoin();
    }
   
    private void DestroyCoin()
    {
        SoundManager.Instance.PlaySound(_audioSource);
        Destroy(gameObject);
    }
}
