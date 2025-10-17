using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int HP = 100;
    public static event Action<int> OnDamage;
    public static event Action OnShowGameOver;

    public void TakeDamage(int damage)
    {
        HP -= damage;

        if (HP <= 0)
        {
            Time.timeScale = 0;
            OnShowGameOver.Invoke();
        }
        OnDamage?.Invoke(HP);
    }
}
