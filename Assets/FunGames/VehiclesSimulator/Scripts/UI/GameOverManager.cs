
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    private bool isGameOver;

    void Start()
    {
       

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
        else
            Debug.LogError("Game Over Panel is not assigned!");
    }

    public void GameOver()
    {
        if (isGameOver)
            return;

        isGameOver = true;

        Debug.Log("GAME OVER FUNCTION CALLED!");

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            gameOverPanel.transform.SetAsLastSibling();
        }

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}
