using NUnit.Framework;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private List<AudioSource> audioSurceses = new List<AudioSource>();  
    
    [SerializeField] private Animator animator;

    private void Start()
    {
        moneyText.text = SaveManager.Instance.Data.coins.ToString();
    }

    public void TryBuyItem(int price, Action onPurchase)
    {
       if (SaveManager.Instance.Data.coins >= price)
       {
            audioSurceses[0].Play();

            SaveManager.Instance.Data.coins -= price;
            onPurchase.Invoke();

           SaveManager.Instance.SaveData();
           moneyText.text = SaveManager.Instance.Data.coins.ToString();
           scoreManager.SetCoins(SaveManager.Instance.Data.coins);

       }
       else
       {
            audioSurceses[1].Play();
            animator.Play("CoinAnimation", -1, 0);
       }
    }

    public void BuyHP(int price)
    {
        TryBuyItem(price, () =>SaveManager.Instance.Data.hp += 5);
    }
}
