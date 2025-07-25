using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text livesText;
    [SerializeField] private Text gameOverText;
    [SerializeField] private Text highScoreText; // 🆕 EKLENDİ

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString().PadLeft(2, '0');
    }

    public void UpdateLives(int lives)
    {
        livesText.text = "x" + lives.ToString();
    }

    public void SetGameOverVisible(bool isVisible)
    {
        gameOverText.enabled = isVisible;
    }

    public void UpdateHighScore(int highScore) // 🆕 EKLENDİ
    {
        highScoreText.text = "HIGH SCORE : " + highScore.ToString().PadLeft(2, '0');
    }
}
