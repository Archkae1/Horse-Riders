using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreMultiplierText, scoreText;
    [SerializeField] private List<TMP_Text> highScoreTexts;

    public void LoadScoreUI(int scoreMultiplier)
    {   
        scoreText.text = "000000";
        scoreMultiplierText.text = "x" + scoreMultiplier.ToString();
    }
    public void ChangeScoreText(int score)
    {
        int capacity = CheckCapacity(score);
        int zeroCounts = 6 - capacity;
        scoreText.text = ((zeroCounts > 0) ? string.Concat(Enumerable.Repeat("0", zeroCounts)) : "") + score.ToString();
    }

    public void ChangeHighScoreText(int maxScore)
    {
        foreach (TMP_Text _highScoreText in highScoreTexts)
        {
            int capacity = CheckCapacity(maxScore);
            int zeroCounts = 6 - capacity;
            _highScoreText.text = ((zeroCounts > 0) ? string.Concat(Enumerable.Repeat("0", zeroCounts)) : "") + maxScore.ToString();
        }
    }

    private void OnScoreMultiplierChanged(int scoreMultiplier)
    {
        scoreMultiplierText.text = "x" + scoreMultiplier.ToString();
    }

    private int CheckCapacity(int num)
    {
        int count = 0;
        while (num > 0)
        {
            count++;
            num = num / 10;
        }
        return count;
    }

    private void OnEnable()
    {
        Score.scoreMultiplierChanged += OnScoreMultiplierChanged;
    }

    private void OnDisable()
    {
        Score.scoreMultiplierChanged -= OnScoreMultiplierChanged;
    }
}
