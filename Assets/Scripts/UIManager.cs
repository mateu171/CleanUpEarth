using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textScore;
    [SerializeField] private TextMeshProUGUI heighestScoreText;
    [SerializeField] private TextMeshProUGUI coinsScore;

    private void OnEnable()
    {
        ScoreManager.OnChangeUI += UpdateUI;
    }

    private void OnDisable()
    {
        ScoreManager.OnChangeUI -= UpdateUI;
    }

    private void UpdateUI(int score,int coins,int heighestScore)
   {
        textScore.text = $"Score: {score}";
        heighestScoreText.text = $"Heighest Score: {heighestScore}";
        coinsScore.text = coins.ToString();
   }

}
