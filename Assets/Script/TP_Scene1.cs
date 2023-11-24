using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TP_Scene1 : MonoBehaviour {
    
    public string targetScene = "Scene1";

    void Awake() {
        DontDestroyOnLoad(gameObject); // Ensure that this object is not destroyed when the scene loads
    }

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene(targetScene);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (scene.name == targetScene) {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            StartCoroutine(DelayedMovePlayerToSpawnPoint());
        }
    }

    IEnumerator DelayedMovePlayerToSpawnPoint() {
        yield return new WaitForSeconds(0.1f);
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) {
            CharacterController controller = player.GetComponent<CharacterController>();
            if (controller != null) {
                controller.enabled = false; // disable CharacterController
            }

            Transform spawnPoint = GameObject.Find("SpawnPoint").transform;
            if (spawnPoint != null) {
                player.transform.position = spawnPoint.position;
            }

            if (controller != null) {
                controller.enabled = true; // re active CharacterController
            }
        }

        Destroy(gameObject); // Destroy the GameObject where TP_Scene1 is located after completing the transfer.
    }


    void MovePlayerToSpawnPoint() {
        Transform spawnPoint = GameObject.Find("SpawnPoint").transform;
        if (spawnPoint != null) {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null) {
                player.transform.position = spawnPoint.position;
                // Here you can also add other logic after the teleportation is complete, 
                //such as adjusting the character's orientation
            }
        }
    }
}
