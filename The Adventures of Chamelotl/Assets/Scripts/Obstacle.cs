using UnityEngine;
using static Fruit;

public class Obstacle : MonoBehaviour
{
    public FruitColor objectColor; 

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has the correct component
        var player = collision.gameObject.GetComponent<PlayerColor>();
        if (player != null)
        {
            // If colors match, ignore the collision
            if (player.characterColor == objectColor)
            {
                Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
            }
        }
    }
}
