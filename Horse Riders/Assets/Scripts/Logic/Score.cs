using System;
using UnityEngine;
using Zenject;

public class Score : MonoBehaviour
{
    private int baseScoreMultiplier = 1;
    private int buffMultiplier = 1;
    private int scoreMultiplier;
    private int score = 0;
    private int maxScore = 0;

    public int getScore => score;

    [Inject] private Player player;
    [SerializeField] private ScorePanel scoreUI;

    public static Action<int> scoreMultiplierChanged;

    private void Update()
    {
        score += (int)(player.getSpeed / 2) * scoreMultiplier;
        scoreUI.ChangeScoreText(score);
    }

    public void Load()
    {
        score = 0;
        if (PlayerPrefs.HasKey("MaxScore")) maxScore = PlayerPrefs.GetInt("MaxScore");
        buffMultiplier = 1;
        scoreMultiplier = baseScoreMultiplier * buffMultiplier;
        scoreUI.ChangeHighScoreText(maxScore);
        scoreUI.LoadScoreUI(scoreMultiplier);
        DisableAccrualScore();
    }

    public void OnEnterRunGameState()
    {
        EnableAccrualScore();
    }

    public void OnEnterPauseGameState()
    {
        DisableAccrualScore();
        DefineHighScore();
    }

    public void OnEnterEndGameState()
    {
        DisableAccrualScore();
        DefineHighScore();
    }

    public void ChangeBuffMultiplier(int buffMultiplier)
    {
        this.buffMultiplier = buffMultiplier;
        scoreMultiplier = buffMultiplier * baseScoreMultiplier;
        scoreMultiplierChanged?.Invoke(scoreMultiplier);
    }

    public void DefineHighScore()
    {
        if (score > maxScore)
        {
            PlayerPrefs.SetInt("MaxScore", score);
            PlayerPrefs.Save();
            maxScore = score;
            scoreUI.ChangeHighScoreText(maxScore);
        }
    }

    public void EnableAccrualScore() => enabled = true;

    public void DisableAccrualScore() => enabled = false;

    private void OnBoostStart(Type type, int time)
    {
        if (type == typeof(ScoreMultiplierBoost))
            ChangeBuffMultiplier(2);
    }

    private void OnBoostEnd(Type type)
    {
        if (type == typeof(ScoreMultiplierBoost))
            ChangeBuffMultiplier(1);
    }

    private void OnEnable()
    {
        Boost.boostStart += OnBoostStart;
        Boost.boostEnd += OnBoostEnd;
    }
    private void OnDisable()
    {
        Boost.boostStart -= OnBoostStart;
        Boost.boostEnd -= OnBoostEnd;
    }
}
