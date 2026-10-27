
using UnityEngine;

public class CarCollision : MonoBehaviour
{
    public GameOverManager gameOverManager;

    private bool hasCollided;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision with: " + collision.gameObject.name);

        if (hasCollided)
            return;

        if (collision.gameObject.CompareTag("Vehicle"))
        {
            hasCollided = true;

            Debug.Log("Traffic vehicle hit!");

            if (gameOverManager != null)
                gameOverManager.GameOver();
            else
                Debug.LogError("Game Over Manager is not assigned!");
        }
    }
}
