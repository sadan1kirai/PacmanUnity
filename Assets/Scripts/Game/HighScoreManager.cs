using UnityEngine;

public static class HighScoreManager
{
    private const string HighScoreKey = "HighScore";

    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt(HighScoreKey, 0);
    }

    public static void SetHighScore(int score)
    {
        if (score > GetHighScore())
        {
            PlayerPrefs.SetInt(HighScoreKey, score);
            PlayerPrefs.Save();
        }
    }
}
