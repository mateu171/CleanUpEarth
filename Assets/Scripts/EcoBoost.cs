using UnityEngine;

public class EcoBoost : GameEntity
{
    public override void ActiveBoost()
    {
       GameObjectManager.Instance.DestroyAllGarbages();
       base.ActiveBoost();
    }

}
