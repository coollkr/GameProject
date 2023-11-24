using UnityEngine;
using TMPro;

public class KeyInteraction : MonoBehaviour
{
    public GameObject uiTextObject; // UI 文本对象的引用
    public bool isKeyObtained = false; // 表示是否拿到钥匙

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiTextObject.SetActive(true); // 显示 UI 文本
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiTextObject.SetActive(false); // 隐藏 UI 文本
        }
    }

    private void Update()
    {
        if (uiTextObject.activeSelf && Input.GetKeyDown(KeyCode.R))
        {
            GetKey();
        }
    }

    private void GetKey()
    {
        // 实现获取钥匙的逻辑
        Debug.Log("Key has been taken.");
        isKeyObtained = true; // 设置钥匙为已获取状态
        
        // 可选：在获取钥匙后禁用或销毁钥匙对象
        gameObject.SetActive(false);
        uiTextObject.SetActive(false);
    }
}
