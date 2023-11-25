using UnityEngine;
using TMPro; 

public class PuzzleCompletionChecker : MonoBehaviour
{
    public GameObject lion1;
    public GameObject lion2;
    public GameObject lion3;
    public GameObject lion4;
    public TextMeshProUGUI completionText; 
    public bool isPuzzleCompleted = false;

    private void CheckPuzzleCompletion()
    {
        if (Mathf.Approximately(lion1.transform.eulerAngles.y, 270f) &&
            Mathf.Approximately(lion2.transform.eulerAngles.y, 0f) &&
            Mathf.Approximately(lion3.transform.eulerAngles.y, 180f) &&
            Mathf.Approximately(lion4.transform.eulerAngles.y, 90f))

        {
            completionText.text = "Puzzle complete!"; 
            completionText.enabled = true;
            isPuzzleCompleted = true;
        }
        else
        {
            completionText.text = "Fail!"; 
            completionText.enabled = true;
            isPuzzleCompleted = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CheckPuzzleCompletion();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            completionText.enabled = false;
        }
    }
}
