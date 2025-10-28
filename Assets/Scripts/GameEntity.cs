using UnityEngine;

public abstract class GameEntity : MonoBehaviour
{
    protected PoolForGarbage<GameEntity> _pool;
    protected virtual void OnDestroy()
    {
        if (GameObjectManager.Instance != null)
        GameObjectManager.Instance.Unregister(this.gameObject);
    }
    protected virtual void Awake()
    {
        if (GameObjectManager.Instance != null)
            GameObjectManager.Instance.Register(this.gameObject);
    }

    public void SetPool(PoolForGarbage<GameEntity> pool)
    {
        _pool = pool;
    }

    public virtual void ActiveBoost()
    {
        if (_pool != null)
        _pool.Release(this);
    }

}
