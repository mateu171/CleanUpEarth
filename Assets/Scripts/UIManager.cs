using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textScore;
    [SerializeField] private TextMeshProUGUI heighestScoreText;
    [SerializeField] private TextMeshProUGUI coinsScore;
    [SerializeField] private GameObject gameOverObject;

    private void OnEnable()
    {
        ScoreManager.OnChangeUI += UpdateUI;
        Player.OnShowGameOver += ShowGameOver;
    }

    private void OnDisable()
    {
        ScoreManager.OnChangeUI -= UpdateUI;
        Player.OnShowGameOver -= ShowGameOver;
    }

    private void UpdateUI(int score,int coins,int heighestScore)
    {
        textScore.text = $"Score: {score}";
        heighestScoreText.text = $"Heighest Score: {heighestScore}";
        coinsScore.text = coins.ToString();
    }

    private void ShowGameOver() => gameOverObject.SetActive(true);

}
