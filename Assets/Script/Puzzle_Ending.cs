using UnityEngine;

public class EndGameTrigger : MonoBehaviour
{
    public EndGameController endGameController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            endGameController.TriggerEndGame();
        }
    }
}
