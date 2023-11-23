using UnityEngine;
using UnityEngine.SceneManagement;

public class TP_Scene1 : MonoBehaviour {
    
    public string targetScene = "Scene1"; 

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to the event before scene load
            SceneManager.LoadScene(targetScene);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (scene.name == targetScene) {
            Transform spawnPoint = GameObject.Find("SpawnPoint").transform;
            if (spawnPoint != null) {
                Transform playerTransform = GameObject.FindGameObjectWithTag("Player")?.transform;
                if (playerTransform != null) {
                    playerTransform.position = spawnPoint.position;
                    // playerTransform.rotation = spawnPoint.rotation;
                }
            }
            SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe from the event
        }
    }
}
