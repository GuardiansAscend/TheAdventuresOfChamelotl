using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveDistance = 3f;  // Distance to move up and down
    public float speed = 2f;         // Movement speed
    public float delayTime = 1f;     // Delay time at top and bottom

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool movingUp = true;    // Track if the platform is moving up or down
    private float delayTimer = 0f;   // Timer to manage delay

    void Start()
    {
        // Set initial position and calculate target position
        startPosition = transform.position;
        targetPosition = startPosition + Vector3.up * moveDistance;
    }

    void Update()
    {
        // Check if the platform is in delay mode
        if (delayTimer > 0f)
        {
            // Reduce delay timer by the time since last frame
            delayTimer -= Time.deltaTime;
            return;  // Exit Update until the delay is over
        }

        // Move the platform
        if (movingUp)
        {
            // Move towards the target position (top position)
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // If the platform reaches the target position, start delay and switch direction
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                movingUp = false;
                delayTimer = delayTime;
            }
        }
        else
        {
            // Move towards the start position (bottom position)
            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);

            // If the platform reaches the start position, start delay and switch direction
            if (Vector3.Distance(transform.position, startPosition) < 0.01f)
            {
                movingUp = true;
                delayTimer = delayTime;
            }
        }
    }
}
