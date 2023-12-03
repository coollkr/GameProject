using UnityEngine;
using System.Collections;

public class EndGameTrigger : MonoBehaviour
{
    public EndGameController endGameController;
    public TP_MainMenu tpSceneScript; 
    public float delayBeforeTeleport = 5.0f; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            endGameController.TriggerEndGame();

            StartCoroutine(DelayedTeleportCoroutine());
        }
    }

    IEnumerator DelayedTeleportCoroutine()
    {
        yield return new WaitForSeconds(delayBeforeTeleport);

        tpSceneScript.TriggerTeleport("MainMenu");
    }
}
