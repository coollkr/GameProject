
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoorPuzzleVoice : MonoBehaviour
{
    public GameObject uiTextObject; // UI 文本对象
    public AudioClip[] knockingSounds; // 敲门声音数组
    private AudioSource audioSource; // 播放声音的音频源
    private int knockSequenceIndex = 0; // 敲门序列的索引
    public List<GameObject> lights; // 灯光列表

    public GameObject characterModel; // 人物模型引用
    private Vector3 startPostion = new Vector3(515, 1.4f, 89); // 人物起始位置
    private Vector3 endPosition = new Vector3(515, 1.4f, -2); // 人物结束位置
    private mouselook cameraScript; // mouselook 脚本的引用
    public GameObject specialLight; // 特定灯光的引用

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // 获取音频源组件
        uiTextObject.SetActive(false); // 初始隐藏 UI 文本对象

            if (specialLight != null)
    {
        specialLight.SetActive(false);
    }

        // 尝试找到主角上的 mouselook 脚本
        GameObject mainCamera = GameObject.FindWithTag("MainCamera"); // 假设您的主摄像机有 "MainCamera" 的标签
        if (mainCamera != null)
        {
            cameraScript = mainCamera.GetComponent<mouselook>();
            if (cameraScript == null)
            {
                Debug.LogError("mouselook script not found on the main camera.");
            }
        }
        else
        {
            Debug.LogError("Main camera not found.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // 检查玩家是否进入触发区
        if (other.CompareTag("Player") && knockSequenceIndex < knockingSounds.Length)
        {
            uiTextObject.SetActive(true); // 显示 UI 文本对象
        }
    }

    void OnTriggerExit(Collider other)
    {
        // 检查玩家是否离开触发区
        if (other.CompareTag("Player"))
        {
            uiTextObject.SetActive(false); // 隐藏 UI 文本对象
        }
    }

    void Update()
    {
        // 检查玩家输入
        if (uiTextObject.activeSelf && Input.GetKeyDown(KeyCode.R))
        {
            uiTextObject.SetActive(false); // 隐藏 UI 文本对象
            PlayKnockingSound(); // 播放敲门声
        }
    }

    void PlayKnockingSound()
    {
        // 播放敲门声音序列中的下一个声音
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
        if (knockSequenceIndex == 4) // 第四次敲门
        {
            yield return new WaitForSeconds(2); // 等待 2 秒

            // 控制灯光闪烁 4 秒
            float endTime = Time.time + 4;
            while (Time.time < endTime)
            {
                foreach (var light in lights)
                {
                    light.SetActive(Random.Range(0, 2) > 0);
                }
                yield return new WaitForSeconds(0.1f);
            }

            // 关闭灯光
            ToggleLights(false);

            yield return new WaitForSeconds(2); // 在关闭灯光后等待 2 秒

            // 激活并移动人物模型
            characterModel.SetActive(true);
            cameraScript.SetFollowCharacterModel(true); // 启用镜头跟随
            characterModel.transform.position = startPostion;

            float moveDuration = 3.0f; // 人物移动持续时间改为 3 秒
            float startTime = Time.time;

            while (Time.time < startTime + moveDuration)
            {
                float t = (Time.time - startTime) / moveDuration;
                characterModel.transform.position = Vector3.Lerp(startPostion, endPosition, t);
                yield return null;
            }

            cameraScript.SetFollowCharacterModel(false); // 禁用镜头跟随
            characterModel.SetActive(false);

            yield return new WaitForSeconds(1); // 禁用镜头跟随后等待 1 秒

            // 关闭人物模型的同时打开所有灯光
            ToggleLights(true);
            if (specialLight != null)
        {
            yield return new WaitForSeconds(0.5f); // 等待 0.5 秒
            specialLight.SetActive(true);
        }
        }
        else
        {
            yield return new WaitForSeconds(delay);
        }

        if (knockSequenceIndex < knockingSounds.Length)
        {
            uiTextObject.SetActive(true); 
        }
        else
        {
            // 最后一次敲门后不执行操作
        }
    }

    void ToggleLights(bool state)
    {
        // 切换所有灯光的状态
        foreach (var light in lights)
        {
            light.SetActive(state);
        }
    }
}
