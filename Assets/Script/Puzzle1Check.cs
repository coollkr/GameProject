using UnityEngine;
using TMPro; 

public class PuzzleCompletionChecker : MonoBehaviour
{
    public GameObject lion1;
    public GameObject lion2;
    public GameObject lion3;
    public GameObject lion4;
    public TextMeshProUGUI completionText; 

    private void CheckPuzzleCompletion()
    {
        Debug.Log(lion1.transform.eulerAngles.y);
        Debug.Log(lion2.transform.eulerAngles.y);
        Debug.Log(lion3.transform.eulerAngles.y);
        Debug.Log(lion4.transform.eulerAngles.y);
        if (Mathf.Approximately(lion1.transform.eulerAngles.y, 270f) &&
            Mathf.Approximately(lion2.transform.eulerAngles.y, 0f) &&
            Mathf.Approximately(lion3.transform.eulerAngles.y, 180f) &&
            Mathf.Approximately(lion4.transform.eulerAngles.y, 90f))

        {
            completionText.text = "Puzzle complete!"; 
            completionText.enabled = true;
        }
        else
        {
            completionText.text = "Fail!"; 
            completionText.enabled = true;
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
