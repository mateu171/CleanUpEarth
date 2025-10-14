using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _score;
    private int _highestScore;
    private int _coins;

    private SaveData _saveData;
    private SaveManager _saveManager;

    public static event Action<int, int, int> OnChangeUI;
    private void Awake()
    {
        _saveManager = new SaveManager();
        _saveData = _saveManager.GetData();

        _highestScore = _saveData.highestScore;
        _coins = _saveData.coins;

    }

    private void UpdateScore()
    {
        _score++;
        _coins++;
        if (_score > _highestScore)
        {
            _highestScore = _score;
        }

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

    private void OnApplicationQuit()
    {
        _saveData.coins = _coins;
        _saveData.highestScore = _highestScore;
        _saveManager.SaveData(_saveData);
    }
}
