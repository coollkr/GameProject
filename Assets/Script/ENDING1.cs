using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndGameController : MonoBehaviour
{
    public GameObject blackScreen;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI creditsText;

    private bool isEnding = false;
    private float scrollSpeed = 30f;

    public void TriggerEndGame()
    {
        blackScreen.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        creditsText.gameObject.SetActive(true);
        isEnding = true;
    }

    void Update()
    {
        if (isEnding)
        {
            creditsText.transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);
        }
    }
}
