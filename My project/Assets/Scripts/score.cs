using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    // The player whose z position determines the score.
    // This should refer to a GameObject named "Player" or be set in the Inspector.
    public Transform player;

    // The UI element that shows the score.
    // In each scene, create a TextMeshPro - Text (UI) object (inside a Canvas)
    // and name it exactly "ScoreText".
    public TextMeshProUGUI scoreText;

    // Holds the current score value.
    private float scoreValue;

    void Start()
    {
        // If not set in the Inspector, try to find the Player by name.
        if (player == null)
        {
            GameObject playerObj = GameObject.Find("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
            else
            {
                Debug.LogError("Player object not found in the scene!");
            }
        }

        // If not set in the Inspector, try to find the ScoreText UI element.
        if (scoreText == null)
        {
            GameObject scoreTextObj = GameObject.Find("ScoreText");
            if (scoreTextObj != null)
            {
                scoreText = scoreTextObj.GetComponent<TextMeshProUGUI>();
            }
            else
            {
                Debug.LogError("ScoreText UI element not found in the scene!\n" +
                               "Please create one by right-clicking in the Hierarchy: UI -> TextMeshPro - Text, " +
                               "and rename it to 'ScoreText'.");
            }
        }
    }

    void Update()
    {
        // Update the score based on the player's z position.
        if (player != null)
        {
            scoreValue = player.position.z;
        }

        // Update the UI, but only if scoreText exists.
        if (scoreText != null)
        {
            scoreText.text = scoreValue.ToString("0");
        }
    }
}
