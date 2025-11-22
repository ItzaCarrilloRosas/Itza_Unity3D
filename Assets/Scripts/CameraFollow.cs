using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    void LateUpdate()
    {
        Vector3 newPos = target.position + offset;

        // Mantener misma altura en Y
        newPos.y = transform.position.y;

        transform.position = newPos;
    }
}
