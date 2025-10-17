using System;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    [SerializeField] private float destroyY = -5.7f;
    [SerializeField] private int damage;

    private AudioSource audioSource;

    public static event Action<AudioSource> OnPlaySound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (transform.position.y < destroyY)
            DestroyGarbage();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.TryGetComponent<Player>(out Player currentPlayer))
       {
            Debug.Log("damage");
            currentPlayer.TakeDamage(damage);
            DestroyGarbage();
       }
    }

    public void DestroyGarbage()
    {
        OnPlaySound?.Invoke(audioSource);
        Destroy(gameObject);
    }
}
