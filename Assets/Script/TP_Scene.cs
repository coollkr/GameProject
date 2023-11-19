using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportPortal : MonoBehaviour {
    
    public string targetScene = "SampleScene"; 
    
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            SceneManager.LoadScene(targetScene);
            SceneManager.sceneLoaded += OnSceneLoaded; // Callback event when the scene has finished loading
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (scene.name == targetScene) {
            Transform spawnPoint = GameObject.Find("SpawnPoint").transform;
            if (spawnPoint) {
                // Re-acquire the player transform in the new scene
                Transform playerTransform = GameObject.FindGameObjectWithTag("Player")?.transform;
                if (playerTransform) {
                    playerTransform.position = spawnPoint.position;
                    // playerTransform.rotation = spawnPoint.rotation;
                }
            }
            SceneManager.sceneLoaded -= OnSceneLoaded; // Remove callback events to prevent multiple calls
        }
    }
}
