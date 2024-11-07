using UnityEngine;
using static Fruit;

public class Obstacle : MonoBehaviour
{
    public FruitColor obstacleColor;  // Color of the obstacle
    private PolygonCollider2D obstacleCollider;  // Reference to the obstacle's PolygonCollider2D
    private GameObject playerGO;  // Reference to the player GameObject

    void Start()
    {
        // Get the PolygonCollider2D component on the obstacle at the start
        obstacleCollider = GetComponent<PolygonCollider2D>();
        playerGO = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        PlayerColor playerColor = playerGO.GetComponent<PlayerColor>();
        if (playerColor != null)
            {
                // Check if the player's color matches the obstacle's color
                if (playerColor.characterColor == obstacleColor)
                {
                    // Disable the obstacle's collider, allowing the player to pass through
                    obstacleCollider.enabled = false;
                }
                else
                {
                    // Player cannot pass, so keep the obstacle's collider enabled
                    obstacleCollider.enabled = true;
                }
            }
    }
}