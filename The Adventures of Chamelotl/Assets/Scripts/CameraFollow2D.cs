using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Vector3 offset = new Vector3(0, 0, -10); // Offset to keep camera behind the player
    public float smoothSpeed = 0.5f; // Smoothing speed for camera movement

    void LateUpdate()
    {
        // Only follow the player on the X and Y axes
        Vector3 desiredPosition = new Vector3(player.position.x, player.position.y, offset.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
