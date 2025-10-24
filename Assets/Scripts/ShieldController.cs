using UnityEngine;

public class ShieldController : MonoBehaviour,IBoost
{
    public  void ActiveBoost()
    {
        Shield.Instance?.ActiveShield();
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
