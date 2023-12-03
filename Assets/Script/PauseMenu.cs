using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausemenu;
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        pausemenu.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update function is called");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Debug.Log("Pausing the game");
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None; // Show the cursor
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        Debug.Log("Resuming the game");
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked; // Hide the cursor
        Cursor.visible = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
