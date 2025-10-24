using System;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private int _currentMoney;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private ScoreManager scoreManager;

    private void Start()
    {
        _currentMoney = SaveManager.Instance.Data.coins;
        moneyText.text = _currentMoney.ToString();
    }

    public void BuyHP()
    {
        if (_currentMoney >= Convert.ToInt32(priceText.text))
        {
            SaveManager.Instance.Data.hp += 5;
            _currentMoney -= Convert.ToInt32(priceText.text);
            moneyText.text = _currentMoney.ToString();
            scoreManager.SetCoins(_currentMoney);
            SaveManager.Instance.SaveData();
            
        }
    }
}
