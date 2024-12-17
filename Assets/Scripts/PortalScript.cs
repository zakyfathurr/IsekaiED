using UnityEngine;

public class PortalScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering the portal is the player
        if (other.CompareTag("Player"))
        {
            QuitGame();
        }
    }

    void QuitGame()
    {
        Debug.Log("Quitting Game...");

                // If running in the Unity Editor, stop play mode
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        // If running as a built game, quit the application
        Application.Quit();
        #endif
    }
}
