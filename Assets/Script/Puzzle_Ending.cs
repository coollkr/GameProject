using UnityEngine;

public class WhiteOutEffect : MonoBehaviour
{
    public GameObject whitePanel; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            whitePanel.SetActive(true); 
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            whitePanel.SetActive(false); 
        }
    }
}
