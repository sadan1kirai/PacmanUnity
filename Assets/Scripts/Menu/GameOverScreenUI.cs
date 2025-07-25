using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreenUI : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text gameOverText;
    public Text yourScoreText;
    public Text pressAnyKeyText;

    private bool isGameOver = false;

    void Start()
    {
        gameOverScreen.SetActive(false);
    }

    public void ShowGameOver(int finalScore)
    {
        isGameOver = true;

        gameOverScreen.SetActive(true);
        yourScoreText.supportRichText = true;
        yourScoreText.text = "YOUR SCORE: <color=#ECF118>" + finalScore + "</color>";
    }

    void Update()
    {
        if (isGameOver && Input.anyKeyDown)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
