using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameObject target;
    [SerializeField] private float speed;

    private const float checkOnDestroy = 0.1f;
    private AudioSource _audioSource;

    public static event Action<AudioSource> OnPlaySound;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("CoinImage");
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
       transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        var dist = Vector3.Distance(transform.position, target.transform.position);

       if (dist < checkOnDestroy)
       {
            DestroyCoin();
       }
    }
   
    private void DestroyCoin()
    {
        OnPlaySound?.Invoke(_audioSource);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        GameObjectManager.Instance.Unregister(this.gameObject);
    }
    private void Awake()
    {
        GameObjectManager.Instance.Register(this.gameObject);
    }
}
