using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoreText;

    private static Score instance;

    void Awake()
    {
        // Ensure only one instance of UIManager exists
        if (instance == null)
        {
            instance = this;

            // Apply DontDestroyOnLoad to the root object
            GameObject rootObject = transform.root.gameObject;
            if (rootObject != null)
            {
                DontDestroyOnLoad(rootObject);
            }
            else
            {
                Debug.LogWarning("Root object not found—cannot apply DontDestroyOnLoad.");
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Debug initial values to check if objects exist
        Debug.Log(scoreText != null ? "scoreText is assigned." : "scoreText is NULL!");
        Debug.Log(player != null ? "player is assigned." : "player is NULL!");

        // Find Player GameObject dynamically if it hasn't been assigned
        if (player == null)
        {
            GameObject playerObject = GameObject.Find("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
            else
            {
                Debug.LogError("Player GameObject not found! Ensure it's named correctly in the Hierarchy.");
            }
        }
    }



    void Update()
    {
        // Prevent update if objects are missing
        if (scoreText == null)
        {
            Debug.LogError("scoreText has been destroyed or is missing!");
            return;
        }

        if (Player == null)
        {
            Debug.LogError("Player has been destroyed or is missing!");
            return;
        }

        Debug.Log($"Player Z Position: {Player.position.z}");
        Debug.Log(scoreText != null ? "ScoreText exists" : "ScoreText is null.");

        // Ensure the UI object stays active
        if (!scoreText.gameObject.activeSelf)
        {
            Debug.LogWarning("ScoreText was inactive—activating it now.");
            scoreText.gameObject.SetActive(true);
        }

        // Update text display
        scoreText.text = Player.position.z.ToString("0");
    }
}
