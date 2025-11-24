using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public float score = 0;
    public float scoreIncreaseSpeed = 1f;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        float high = PlayerPrefs.GetFloat("HighScore", 0);
        highScoreText.text = "HighScore: " + Mathf.FloorToInt(high);
    }

    void Update()
    {
        // Incrementa el score mientras el jugador avanza
        score += scoreIncreaseSpeed * Time.deltaTime;
        scoreText.text = "Score: " + Mathf.FloorToInt(score);
    }

    void OnDestroy()
    {
        float highscore = PlayerPrefs.GetFloat("HighScore", 0f);

        if (score > highscore)
        {
            PlayerPrefs.SetFloat("HighScore", score);
            PlayerPrefs.Save();
        }
    }
}
