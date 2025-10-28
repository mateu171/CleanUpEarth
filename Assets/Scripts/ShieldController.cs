using UnityEngine;

public class ShieldController : GameEntity
{
    public override void ActiveBoost()
    {
        Shield.Instance?.ActiveShield();
        base.ActiveBoost();
    }
}
