using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textScore;
    [SerializeField] private TextMeshProUGUI heighestScoreText;
    [SerializeField] private TextMeshProUGUI coinsScore;

    private SaveData _saveData;
    private SaveManager _saveManager;

    private int _score;
    private int _heighestScore;
    private int _coins;

    private void Start()
    {
        _saveManager = new SaveManager();
        _saveData = _saveManager.GetData();

        _heighestScore = _saveData.heighestScore;
        _coins = _saveData.coins;

        textScore.text = $"Score: {_score}";
        heighestScoreText.text = $"Heighest Score: {_heighestScore}";
        coinsScore.text = _coins.ToString();
    }

    private void UpdateScore()
    {
        _score++;
        textScore.text = $"Score: {_score}";

        if (_score > _heighestScore)
        {
            _heighestScore = _score;
            heighestScoreText.text = $"Heighest Score: {_heighestScore}";
        }

        UpdateCoinsScore();
    }

    private void UpdateCoinsScore()
    {
        _coins++;
        coinsScore.text = _coins.ToString();
    }
    private void OnEnable()
    {
        HoverInteraction.OnChangeScore += UpdateScore;
    }
    private void OnDisable()
    {
        HoverInteraction.OnChangeScore -= UpdateScore;
    }

    private void OnApplicationQuit()
    {
        _saveData.coins = _coins;
        _saveData.heighestScore = _heighestScore;
        _saveManager.SaveData(_saveData);
    }
}
