using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    void Start() {
        DestroyOrDisableMainCharacter();
        ResetCursorState();
    }

    void DestroyOrDisableMainCharacter() {
        GameObject mainCharacter = GameObject.FindGameObjectWithTag("Player");
        if (mainCharacter != null) {
            Destroy(mainCharacter); 
        }
    }

    void ResetCursorState() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
