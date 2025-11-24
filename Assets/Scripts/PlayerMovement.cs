using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 5f;      // Velocidad inicial hacia adelante
    public float sideSpeed = 5f;         // Velocidad lateral

    [Header("Dificultad")]
    public float speedIncreaseRate = 0.2f;     // Cuánto aumenta la velocidad
    public float speedIncreaseInterval = 3f;   // Cada cuántos segundos aumenta
    private float nextSpeedUpTime = 0f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        nextSpeedUpTime = Time.time + speedIncreaseInterval;
    }

    void FixedUpdate()
    {
        // Movimiento automático hacia adelante
        rb.MovePosition(rb.position + Vector3.forward * forwardSpeed * Time.fixedDeltaTime);

        // Movimiento lateral controlado
        float moveX = Input.GetAxis("Horizontal") * sideSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + new Vector3(moveX, 0f, 0f));

        // Curva de dificultad (aumento progresivo)
        IncreaseDifficulty();
    }

    void IncreaseDifficulty()
    {
        if (Time.time >= nextSpeedUpTime)
        {
            forwardSpeed += speedIncreaseRate;   // Aumenta velocidad
            nextSpeedUpTime = Time.time + speedIncreaseInterval;
        }
    }

    void OnDestroy()
    {
        float highscore = PlayerPrefs.GetFloat("HighScore", 0f);

        // Si deseas usar "score" aquí, debe venir del ScoreManager
        if (ScoreManager.instance != null)
        {
            float currentScore = ScoreManager.instance.score;

            if (currentScore > highscore)
            {
                PlayerPrefs.SetFloat("HighScore", currentScore);
                PlayerPrefs.Save();
            }
        }
    }
}
