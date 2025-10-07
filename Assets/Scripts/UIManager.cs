using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textScore;

    private int _score;

    private void Start()
    {
        textScore.text = $"Score: {_score}";
    }

    private void OnEnable()
    {
        HoverInteraction.OnChangeScore += UpdateScore;
    }
    private void OnDisable()
    {
        HoverInteraction.OnChangeScore -= UpdateScore;
    }
    private void UpdateScore()
    {
        _score++;
        textScore.text = $"Score: {_score}";
    }
}
