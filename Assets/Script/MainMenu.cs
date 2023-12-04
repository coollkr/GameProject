using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start() 
    {
        ResetCursorState();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Loads the first level
    }

    public void QuitGame()
    {
        Application.Quit(); 
    }

    private void ResetCursorState()
    {
        Cursor.visible = true; // Make sure the mouse cursor is visible
        Cursor.lockState = CursorLockMode.None; // Make sure the mouse cursor is not locked or restricted
    }
}
