using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class DoorInteraction : MonoBehaviour
{
    public GameObject uiTextObject; 
    public PuzzleCompletionChecker puzzleChecker; 
    public KeyInteraction keyInteraction; 
    public string targetScene = "SampleScene"; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UpdateUIText();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiTextObject.SetActive(false); 
        }
    }

    private void UpdateUIText()
    {
        if (puzzleChecker.isPuzzleCompleted && keyInteraction.isKeyObtained)
        {
            uiTextObject.GetComponent<TextMeshProUGUI>().text = "You solve ALL the puzzles. Welcome To the Hell, Press R to next building.";
            uiTextObject.SetActive(true);
        }
        else
        {
            uiTextObject.GetComponent<TextMeshProUGUI>().text = "Door is LOCKED, solve all puzzles.";
            uiTextObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (uiTextObject.activeSelf && Input.GetKeyDown(KeyCode.R) && puzzleChecker.isPuzzleCompleted && keyInteraction.isKeyObtained)
        {
            SceneTransitionManager.Instance.LoadScene(targetScene);
        }
    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode) 
    {
        if (scene.name == targetScene) 
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
