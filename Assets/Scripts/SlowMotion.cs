using System.Collections;
using UnityEngine;

public class SlowMotion : GameEntity
{
    [SerializeField] private float delay = 5;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D collider;

    protected override void Awake()
    {
        base.Awake();
        GameObjectManager.Instance.Register(this.gameObject);
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }
    public override void ActiveBoost()
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
        base.ActiveBoost();
    }
}
