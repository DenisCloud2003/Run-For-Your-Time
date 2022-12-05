using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuPanel;
    public GameObject howToPlayUI;

    public void Playgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    public void HowToPlay()
    {
        howToPlayUI.SetActive(true);
        if (pauseMenuPanel == null)
            return;
        pauseMenuPanel.SetActive(false);
    }

    public void Close()
    {
        howToPlayUI.SetActive(false);
        Time.timeScale = 1f;
    }
    
    public void Quitgame()
    {
        Application.Quit();
    }
}
