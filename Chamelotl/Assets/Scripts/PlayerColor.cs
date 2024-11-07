using UnityEngine;
using static Fruit;

public class PlayerColor : MonoBehaviour
{
    public FruitColor characterColor;

    void Start()
    {
        characterColor = FruitColor.White;
    }

    public void ChangeColor(FruitColor newColor)
    {
        characterColor = newColor;

        // Change the color of the player sprite
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has the correct component
        var fruit = collision.gameObject.GetComponent<Fruit>();
        if (fruit != null)
        {
            ChangeColor(fruit.fruitColor);
            Destroy(collision.gameObject);
        }
    }
}
