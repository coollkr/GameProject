using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TP_Scene1 : MonoBehaviour {
    
    public string targetScene = "Scene1";

    void Awake() {
        DontDestroyOnLoad(gameObject); // 保证场景加载时不销毁此对象
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
                controller.enabled = false; // 禁用 CharacterController
            }

            Transform spawnPoint = GameObject.Find("SpawnPoint").transform;
            if (spawnPoint != null) {
                player.transform.position = spawnPoint.position;
            }

            if (controller != null) {
                controller.enabled = true; // 重新启用 CharacterController
            }
        }

        Destroy(gameObject); // 完成传送后销毁TP_Scene1所在的GameObject
    }


    void MovePlayerToSpawnPoint() {
        Transform spawnPoint = GameObject.Find("SpawnPoint").transform;
        if (spawnPoint != null) {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null) {
                player.transform.position = spawnPoint.position;
                // 这里也可以添加其他传送完成后的逻辑，如调整角色朝向等
            }
        }
    }
}
