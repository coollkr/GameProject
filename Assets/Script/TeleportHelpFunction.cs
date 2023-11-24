using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance { get; private set; }
    private string currentTargetScene; // 当前要加载的场景名称

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(string sceneName)
    {
        currentTargetScene = sceneName; // 设置当前目标场景名称
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(sceneName);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == currentTargetScene)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            StartCoroutine(DelayedMovePlayerToSpawnPoint());
        }
    }

    IEnumerator DelayedMovePlayerToSpawnPoint()
    {
        yield return new WaitForSeconds(0.1f);

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            CharacterController controller = player.GetComponent<CharacterController>();
            if (controller != null)
            {
                controller.enabled = false;
            }

            Transform spawnPoint = GameObject.Find("SpawnPoint").transform;
            if (spawnPoint != null)
            {
                player.transform.position = spawnPoint.position;
            }

            if (controller != null)
            {
                controller.enabled = true;
            }
        }
    }
}
