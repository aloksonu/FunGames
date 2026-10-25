using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUIManager : MonoBehaviour
{
    public GameObject PauseMenuPanel;

    public void PauseMenuOpenButton()
    {
        Time.timeScale = 0f;
        PauseMenuPanel.SetActive(true);
    }

    public void PauseMenuCloseButton()
    {
        Time.timeScale = 1f;
        PauseMenuPanel.SetActive(false);
    }

    public void RestartButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void HomeButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
