using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Si chocamos un obstáculo
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Die();
        }
    }

    void Die()
    {
        // Reiniciar escena
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
