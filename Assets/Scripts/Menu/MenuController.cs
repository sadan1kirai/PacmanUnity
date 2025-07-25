using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Text[] menuItems;     // Play ve Exit
    public Text arrowText;       // > işareti olan Text
    public float offsetX = -40f; // Ok sola hizalansın

    private int selectedIndex = 0;

    void Start()
    {
        UpdateArrowPosition();
    }

    void Update()
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

    void UpdateArrowPosition()
    {
        Vector3 pos = menuItems[selectedIndex].rectTransform.position;
        arrowText.rectTransform.position = new Vector3(
            pos.x + offsetX,
            pos.y,
            pos.z
        );
    }

    void ExecuteSelection()
    {
        if (selectedIndex == 0)
        {
            SceneManager.LoadScene("Pacman");
        }
        else if (selectedIndex == 1)
        {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
            Application.Quit();
    #endif
        }
    }

}
