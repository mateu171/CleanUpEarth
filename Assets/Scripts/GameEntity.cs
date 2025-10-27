using UnityEngine;

public abstract class GameEntity : MonoBehaviour
{
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
}
