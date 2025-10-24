using System;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    [SerializeField] private float destroyY = -5.7f;
    [SerializeField] private int damage;

    private AudioSource audioSource;

    public static event Action<AudioSource> OnPlaySound;

    public virtual void Start()
    {
        GameObjectManager.Instance.Register(this.gameObject);
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
        if (audioSource != null) 
        OnPlaySound?.Invoke(audioSource);

        GameObjectManager.Instance.Unregister(this.gameObject);
        Destroy(gameObject);
    }
}
