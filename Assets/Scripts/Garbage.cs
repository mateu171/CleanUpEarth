using System;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    [SerializeField] private float destroyY = -5.7f;
    [SerializeField] private int damage;

    private AudioSource _audioSource;
    private PoolForGarbage<Garbage> _pool;

    protected virtual void Awake()
    {
        if (GameObjectManager.Instance != null)
            GameObjectManager.Instance.Register(this.gameObject);
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (transform.position.y < destroyY)
            DestroyGarbage();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player currentPlayer))
        {
            currentPlayer.TakeDamage(damage);
            DestroyGarbage();
        }
    }
    public void DestroyGarbage()
    {
        if (_audioSource != null && SoundManager.Instance != null) 
        SoundManager.Instance.PlaySound(_audioSource);

        if (GameObjectManager.Instance != null)
            GameObjectManager.Instance.Register(this.gameObject);

        _pool.Release(this);
    }

    public void SetPool(PoolForGarbage<Garbage> pool)
    {
        _pool = pool;
    }
}
