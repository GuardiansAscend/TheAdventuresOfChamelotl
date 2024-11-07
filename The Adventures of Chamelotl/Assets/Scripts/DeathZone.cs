using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    // This function is called when a trigger event occurs
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering the trigger is tagged "Player"
        if (other.CompareTag("Player"))
        {
            // Reload the current active scene
            Debug.Log("Player has entered the death zone!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

