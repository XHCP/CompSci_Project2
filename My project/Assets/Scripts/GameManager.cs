using UnityEngine;
using UnityEngine.SceneManagement; // Added namespace for SceneManager

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1f;

    public void EndGame()
    {
        if (!gameHasEnded) // Simplified condition
        {
            gameHasEnded = true;
            Debug.Log("GameOver"); // Fixed capitalization
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
