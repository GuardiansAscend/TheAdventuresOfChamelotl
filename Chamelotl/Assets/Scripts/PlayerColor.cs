using UnityEngine;
using static Fruit;

public class PlayerColor : MonoBehaviour
{
    public FruitColor characterColor;
    public Sprite playerSpriteYellow;
    public Sprite playerSpriteRed;
    public Sprite playerSpritePurple;
    public Sprite playerSpriteBrown;
    public RuntimeAnimatorController yellowAnimatorController;
    public RuntimeAnimatorController redAnimatorController;
    public RuntimeAnimatorController purpleAnimatorController;
    public RuntimeAnimatorController brownAnimatorController;



    public void ChangeColor(FruitColor newColor)
    {
        characterColor = newColor;
        Sprite newColorSprite = null;
        RuntimeAnimatorController newAnimatorController = null;

        switch (newColor)
        {
            case FruitColor.Yellow:
                newColorSprite = playerSpriteYellow;
                newAnimatorController = yellowAnimatorController;
                break;
            case FruitColor.Red:
                newColorSprite = playerSpriteRed;
                newAnimatorController = redAnimatorController;
                break;
            case FruitColor.Purple:
                newColorSprite = playerSpritePurple;
                newAnimatorController = purpleAnimatorController;
                break;
            case FruitColor.Brown:
                newColorSprite = playerSpriteBrown;
                newAnimatorController = brownAnimatorController;
                break;
        }

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null && newColorSprite != null)
        {
            spriteRenderer.sprite = newColorSprite;
        }
        else
        {
            Debug.LogWarning("SpriteRenderer or newSprite is not set.");
        }

        Animator animator = GetComponent<Animator>();

        if (animator != null && newAnimatorController != null)
        {
            animator.runtimeAnimatorController = newAnimatorController;
        }
        else
        {
            Debug.LogWarning("Animator or newAnimatorController is not set.");
        }
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
