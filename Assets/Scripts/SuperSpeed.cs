using UnityEngine;

public class SuperSpeed : MonoBehaviour
{
    public float multiplier = 2f;
    public float duration = 3f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().SpeedBoost(multiplier, duration);

            Destroy(gameObject);
        }
    }
}
