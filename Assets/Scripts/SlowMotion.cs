using System.Collections;
using UnityEngine;

public class SlowMotion : MonoBehaviour, IBoost
{
    [SerializeField] private float delay = 5;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D collider;

    private void Awake()
    {
        GameObjectManager.Instance.Register(this.gameObject);
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }
    public void ActiveBoost()
    {
        spriteRenderer.enabled = false;
        collider.enabled = false;

        Time.timeScale = Time.timeScale / 2;
        StartCoroutine(SlowMotionTimer());
    }

    private IEnumerator SlowMotionTimer()
    {
        yield return new WaitForSecondsRealtime(delay);
        Time.timeScale = 1;
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        GameObjectManager.Instance.Unregister(this.gameObject);
    }
}
