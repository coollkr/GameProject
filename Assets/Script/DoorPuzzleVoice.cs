using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;


public class DoorPuzzleVoice : MonoBehaviour
{
    public GameObject uiTextObject; // R 的 UI 文本对象
    public AudioClip[] knockingSounds; // 预先录制好的敲门声音数组
    private AudioSource audioSource; // 柜子的 AudioSource 组件
    private int knockSequenceIndex = 0; // 当前敲门声音序列索引
    public List<GameObject> lights;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        uiTextObject.SetActive(false); // 初始时隐藏 UI
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && knockSequenceIndex < knockingSounds.Length)
        {
            uiTextObject.SetActive(true); // 显示 R 的 UI
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiTextObject.SetActive(false); // 隐藏 R 的 UI
        }
    }

    void Update()
    {
        if (uiTextObject.activeSelf && Input.GetKeyDown(KeyCode.R))
        {
            uiTextObject.SetActive(false); // 隐藏 R 的 UI
            PlayKnockingSound();
        }
    }

    void PlayKnockingSound()
    {
        if (knockSequenceIndex < knockingSounds.Length)
        {
            AudioClip knockSound = knockingSounds[knockSequenceIndex];
            audioSource.PlayOneShot(knockSound);
            knockSequenceIndex++;
            StartCoroutine(ShowUIAfterSound(knockSound.length));
        }
    }

    IEnumerator ShowUIAfterSound(float delay)
        {
            yield return new WaitForSeconds(delay);
            if (knockSequenceIndex < knockingSounds.Length)
            {
                uiTextObject.SetActive(true); // 声音播放完毕后再次显示 R 的 UI
            }
            else if (knockSequenceIndex == 4) // 检查是否是第四次敲门
            {
                ToggleLights(false); // 关闭所有灯
                yield return new WaitForSeconds(5); // 等待五秒
                ToggleLights(true); // 重新打开所有灯
            }
        }

        void ToggleLights(bool state)
        {
            foreach (var light in lights)
            {
                light.SetActive(state);
            }
        }
}
