using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndGameTrigger : MonoBehaviour
{
    public EndGameController endGameController;
    public float delayBeforeRestart = 5.0f; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            endGameController.TriggerEndGame();

            StartCoroutine(DelayedRestartCoroutine());
        }
    }

    IEnumerator DelayedRestartCoroutine()
    {
        yield return new WaitForSeconds(delayBeforeRestart);
        SceneManager.LoadScene("MainMenu"); 
    }
}
