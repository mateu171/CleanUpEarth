using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _maxHP = 100;
    private int _currentHP;

    public static event Action<float, float> OnDamage;
    public static event Action OnShowGameOver;

    [SerializeField] private GameObject pause;
    public int MaxHP { get { return _maxHP; } }

    private void Start()
    {
        _maxHP = SaveManager.Instance.Data.hp;
        _currentHP = _maxHP;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void TakeDamage(int damage)
    {
        _currentHP -= damage;

        if (_currentHP <= 0)
        {
            Time.timeScale = 0;
            GameObjectManager.Instance.DestroyAllGarbages();
            OnShowGameOver?.Invoke();
        }
        OnDamage?.Invoke(_currentHP, _maxHP);
    }

}
