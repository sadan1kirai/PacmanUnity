using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NameInputManager : MonoBehaviour
{
    public GameObject nameInputPanel;
    public InputField nameInputField;

    private System.Action onNameEntered;

    public void Open(System.Action callback)
    {
        nameInputPanel.SetActive(true);
        nameInputField.text = "";
        nameInputField.Select();
        nameInputField.ActivateInputField();
        onNameEntered = callback;
    }

    void Update()
    {
        if (nameInputPanel.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            string name = nameInputField.text.Trim();
            if (!string.IsNullOrEmpty(name))
            {
                PlayerPrefs.SetString("PlayerName", name);
                PlayerPrefs.Save();
                nameInputPanel.SetActive(false);
                onNameEntered?.Invoke();
            }
        }
    }
}
