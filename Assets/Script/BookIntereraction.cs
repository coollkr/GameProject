using UnityEngine;
using TMPro;
using System.Collections;

public class BookInteraction : MonoBehaviour
{
    public GameObject greyBackgroundCanvas; 
    public TMP_Text bookText; 
    public GameObject openBookPrompt; 
    public GameObject closeBookPrompt; 
    public Collider bookCollider; 

    private bool isPlayerNear = false;
    private bool isBookOpen = false;
    private Coroutine fadeInCoroutine;


    void Start()
    {
        greyBackgroundCanvas.SetActive(false);
        openBookPrompt.SetActive(false);
        closeBookPrompt.SetActive(false);
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
            if (fadeInCoroutine != null)
            {
                StopCoroutine(fadeInCoroutine);
            }
            fadeInCoroutine = StartCoroutine(FadeInText(openBookPrompt, "Press R to Open Book", 1f));
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            CloseBook();
            if (fadeInCoroutine != null)
            {
                StopCoroutine(fadeInCoroutine);
                fadeInCoroutine = null;
            }
        }
    }

    void ToggleBookUI()
    {
        isBookOpen = !isBookOpen;
        greyBackgroundCanvas.SetActive(isBookOpen);
        if (isBookOpen)
        {
            StartCoroutine(FadeInTextByLine(bookText, 0.5f)); 
        }
        else
        {
            bookText.gameObject.SetActive(false);
        }
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

    IEnumerator FadeInText(GameObject promptObject, string fullText, float duration)
    {
        promptObject.SetActive(true); 
        TMP_Text textComponent = promptObject.GetComponent<TMP_Text>();
        if (textComponent != null)
        {
            textComponent.text = "";
            float timePerCharacter = duration / fullText.Length;
            foreach (char c in fullText)
            {
                textComponent.text += c;
                yield return new WaitForSeconds(timePerCharacter);
            }
        }
        else
        {
            Debug.LogError("TMP_Text component not found on the object!");
        }
    }

    IEnumerator FadeInTextByLine(TMP_Text textComponent, float timePerLine)
    {
        textComponent.gameObject.SetActive(true);
        string fullText = textComponent.text; 
        textComponent.text = "";
        string[] lines = fullText.Split('\n');

        foreach (string line in lines)
        {
            textComponent.text += line + "\n";
            yield return new WaitForSeconds(timePerLine); 
        }
    }

}