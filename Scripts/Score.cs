using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private float _score = 0;

    private void OnEnable()
    {
        PlayerController.AddScore += AddScore;
    }

    private void OnDisable()
    {
        PlayerController.AddScore -= AddScore;
    }

    private void AddScore()
    {
        _score++;

        _scoreText.text = "Ñ÷¸ò: " + _score.ToString();
    }
}