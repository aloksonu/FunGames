using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUIManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public AudioClip crashSound;
    public AudioSource audioSource;
    public bool isGameOver;

    public void GameOver()
    {
        if (isGameOver) { return; }
        isGameOver = true;

        audioSource.PlayOneShot(crashSound);

        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
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
