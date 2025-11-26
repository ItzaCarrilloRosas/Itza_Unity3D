using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 5f;      
    public float sideSpeed = 5f;         

    [Header("Dificultad")]
    public float speedIncreaseRate = 0.2f;     
    public float speedIncreaseInterval = 3f;   
    private float nextSpeedUpTime = 0f;

    [Header("Boost")]
    private bool isBoosting = false;
    private float boostEndTime = 0f;

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

        // Movimiento lateral
        float moveX = Input.GetAxis("Horizontal") * sideSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + new Vector3(moveX, 0f, 0f));

        // Curva de dificultad
        IncreaseDifficulty();

        // Terminar Boost si ya pasó el tiempo
        if (isBoosting && Time.time > boostEndTime)
        {
            forwardSpeed /= 2f;
            isBoosting = false;
        }
    }

    void IncreaseDifficulty()
    {
        if (Time.time >= nextSpeedUpTime)
        {
            forwardSpeed += speedIncreaseRate;
            nextSpeedUpTime = Time.time + speedIncreaseInterval;
        }
    }

    // 🔥 MÉTODO QUE HACÍA FALTA 🔥
    public void SpeedBoost(float multiplier, float duration)
    {
        if (!isBoosting)
        {
            forwardSpeed *= multiplier;   // Aumenta la velocidad
        }

        isBoosting = true;
        boostEndTime = Time.time + duration;
    }

    void OnDestroy()
    {
        float highscore = PlayerPrefs.GetFloat("HighScore", 0f);

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
