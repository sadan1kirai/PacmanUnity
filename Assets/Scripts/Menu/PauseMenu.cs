using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public CanvasGroup pauseCanvas;
    public Text[] menuItems;    
    public Text arrowText;   
    public float offsetX = -40f; 

    private int selectedIndex = 0;
    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
                Pause();
            else
                Resume();
        }

        if (isPaused)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                selectedIndex = (selectedIndex - 1 + menuItems.Length) % menuItems.Length;
                UpdateArrowPosition();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                selectedIndex = (selectedIndex + 1) % menuItems.Length;
                UpdateArrowPosition();
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                ExecuteSelection();
            }
        }
    }

    private void UpdateArrowPosition()
    {
        Vector3 pos = menuItems[selectedIndex].rectTransform.position;
        arrowText.rectTransform.position = new Vector3(
            pos.x + offsetX,
            pos.y,
            pos.z
        );
    }

    private void ExecuteSelection()
    {
        if (selectedIndex == 0)
        {
            Resume();
        }
        else if (selectedIndex == 1)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("StartMenu");
        }
    }

    private void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;
        SetPausePanelVisible(true);
        selectedIndex = 0;
        UpdateArrowPosition();
    }

    private void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;
        SetPausePanelVisible(false);
    }

    private void SetPausePanelVisible(bool isVisible)
    {
        pauseCanvas.alpha = isVisible ? 1 : 0;
        pauseCanvas.interactable = isVisible;
        pauseCanvas.blocksRaycasts = isVisible;
    }
}
