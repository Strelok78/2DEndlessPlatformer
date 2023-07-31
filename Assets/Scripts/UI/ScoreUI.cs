using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreUI : MonoBehaviour
{
    [SerializeField] private PlayerScore _playerScore;
    private TextMeshProUGUI _textMeshPro;

    private void OnEnable()
    {
        _playerScore.OnScoreChanged += UpdateScoreText;
    }

    private void OnDisable()
    {
        _playerScore.OnScoreChanged -= UpdateScoreText;
    }

    private void Start()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    private void UpdateScoreText(int score)
    {
        _textMeshPro.text = "Score: " + score;
    }
}
