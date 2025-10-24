using UnityEngine;

public class EcoBoost : MonoBehaviour, IBoost
{
    public void ActiveBoost()
    {
       GameObjectManager.Instance.DestroyAllGarbages();
        Destroy(gameObject);
    }

}
