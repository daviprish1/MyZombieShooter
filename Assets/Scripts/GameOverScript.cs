using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

    private GameObject panel;

    void Awake()
    {
        // Get the panel with buttons
        panel = GameObject.FindGameObjectWithTag("MenuPanel");

        // Disable them
        HideButtons();
    }

    public void HideButtons()
    {
        panel.gameObject.SetActive(false);
    }

    public void ShowButtons()
    {
        panel.gameObject.SetActive(true);
    }

    public void ExitToMenu()
    {
        // Go to menu
        SceneManager.LoadScene("Menu");
    }

    public void RestartGame()
    {
        // Reload the level
        SceneManager.LoadScene("Scene1");
    }
}
