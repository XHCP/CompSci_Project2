using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;

    void OnCollisionEnter(Collision collisionInfo) // Fixed method name capitalization
    {
        if (collisionInfo.collider.CompareTag("Obstacle")) // Optimized tag comparison
        {
            if (movement != null)
            {
                movement.enabled = false;
            }
            else
            {
                Debug.LogError("PlayerMovement reference is missing!");
            }

            // Ensure GameManager exists before calling EndGame()
            GameManager gameManager = Object.FindFirstObjectByType<GameManager>();
            if (gameManager != null)
            {
                gameManager.EndGame();
            }
            else
            {
                Debug.LogError("GameManager not found! Ensure it exists in the scene.");
            }
        }
        
    }
}

