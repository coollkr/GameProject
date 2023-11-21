using UnityEngine;
using TMPro;

public class BookInteraction : MonoBehaviour
{
    public GameObject greyBackgroundCanvas; 
    public TMP_Text bookText; 
    public GameObject openBookPrompt; 
    public GameObject closeBookPrompt; 
    public Collider bookCollider; 

    private bool isPlayerNear = false;
    private bool isBookOpen = false;

    void Start()
    {
        greyBackgroundCanvas.SetActive(false); 
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.R))
        {
            ToggleBookUI();
        }
    }

private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        isPlayerNear = true;
        openBookPrompt.SetActive(true); 
    }
}

private void OnTriggerExit(Collider other)
{
    if (other.CompareTag("Player"))
    {
        isPlayerNear = false;
        CloseBook(); 
    }
}

void ToggleBookUI()
{
    isBookOpen = !isBookOpen;
    greyBackgroundCanvas.SetActive(isBookOpen); 
    bookText.gameObject.SetActive(isBookOpen); 
    closeBookPrompt.SetActive(isBookOpen); 
    openBookPrompt.SetActive(!isBookOpen); 
}

public void CloseBook()
{
    isBookOpen = false;
    greyBackgroundCanvas.SetActive(false); 
    bookText.gameObject.SetActive(false); 
    closeBookPrompt.SetActive(false); 
    openBookPrompt.SetActive(isPlayerNear); 
}

}
