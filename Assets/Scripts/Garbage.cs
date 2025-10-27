using System;
using UnityEngine;

public class Garbage : GameEntity
{
    [SerializeField] private float destroyY = -5.7f;
    [SerializeField] private int damage;

    private AudioSource audioSource;

    protected override void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
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
        if (audioSource != null && SoundManager.Instance != null) 
        SoundManager.Instance.PlaySound(audioSource);
        Destroy(gameObject);
    }
}
