using UnityEngine;
using TMPro;

public class BookInteraction : MonoBehaviour
{
    public GameObject greyBackgroundCanvas; // 整个Canvas
    public TMP_Text bookText; // 显示书本内容的TextMeshPro对象
    public GameObject openBookPrompt; // “Press R to Open the Book”的提示
    public GameObject closeBookPrompt; // “Press R to Close the Book”的提示
    public Collider bookCollider; // 书本的Collider

    private bool isPlayerNear = false;
    private bool isBookOpen = false;

    void Start()
    {
        greyBackgroundCanvas.SetActive(false); // 确保开始时整个Canvas是隐藏的
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
        openBookPrompt.SetActive(true); // 只显示打开书本的提示
    }
}

private void OnTriggerExit(Collider other)
{
    if (other.CompareTag("Player"))
    {
        isPlayerNear = false;
        CloseBook(); // 当玩家离开时关闭书本
    }
}

void ToggleBookUI()
{
    isBookOpen = !isBookOpen;
    greyBackgroundCanvas.SetActive(isBookOpen); // 控制整个Canvas的显示和隐藏
    bookText.gameObject.SetActive(isBookOpen); // 控制书本内容的显示和隐藏
    closeBookPrompt.SetActive(isBookOpen); // 控制关闭书本的提示显示和隐藏
    openBookPrompt.SetActive(!isBookOpen); // 控制打开书本的提示显示和隐藏
}

public void CloseBook()
{
    isBookOpen = false;
    greyBackgroundCanvas.SetActive(false); // 隐藏整个Canvas
    bookText.gameObject.SetActive(false); // 隐藏书本内容
    closeBookPrompt.SetActive(false); // 隐藏关闭书本的提示
    openBookPrompt.SetActive(isPlayerNear); // 如果玩家仍然靠近，则显示打开书本的提示
}

}
