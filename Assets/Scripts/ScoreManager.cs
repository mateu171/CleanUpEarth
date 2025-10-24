using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _score;

    private int _highestScore;

    private int _coins;
    public int Coin { get { return _coins; } }
    public int HighestScore { get { return _highestScore; } }


    public static event Action<int, int, int> OnChangeUI;
    private void Awake()
    {
      _highestScore = SaveManager.Instance.Data.highestScore;
        _coins = SaveManager.Instance.Data.coins;
    }

    private void UpdateScore()
    {
        _score++;
        _coins++;
        if (_score > _highestScore)
        {
            _highestScore = _score;
        }

        SaveManager.Instance.Data.coins = _coins;
        SaveManager.Instance.Data.highestScore = _highestScore;
        SaveManager.Instance.SaveData();

        NotifyUI();
    }

    private void NotifyUI()
    {
        OnChangeUI?.Invoke(_score, _coins, _highestScore);
    }

    private void OnEnable()
    {
        HoverInteraction.OnChangeScore += UpdateScore;
        NotifyUI();

    }
    private void OnDisable()
    {
        HoverInteraction.OnChangeScore -= UpdateScore;
    }

    public void SetCoins(int value)
    {
        _coins = value;
        SaveManager.Instance.Data.coins = _coins;
        SaveManager.Instance.SaveData();
        NotifyUI();
    }

}
