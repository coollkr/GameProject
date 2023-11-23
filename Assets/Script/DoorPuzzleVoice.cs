using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class DoorPuzzleVoice : MonoBehaviour
{
    public GameObject uiTextObject; // UI Text object that will be toggled
    public AudioClip[] knockingSounds; // Array of knocking sounds
    private AudioSource audioSource; // Audio source for playing knocking sounds
    private int knockSequenceIndex = 0; // Index to track the current knock in the sequence
    public List<GameObject> lights; // List of lights to be controlled

    public GameObject characterModel; // Reference to the character model
    private Vector3 startPostion = new Vector3(-32, 1.4f, -183); // Start position of the character
    private Vector3 endPosition = new Vector3(-32, 1.4f, -272); // End position of the character

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the audio source component
        uiTextObject.SetActive(false); // Initially hide the UI text object
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the trigger zone
        if (other.CompareTag("Player") && knockSequenceIndex < knockingSounds.Length)
        {
            uiTextObject.SetActive(true); // Show the UI text object
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the player exits the trigger zone
        if (other.CompareTag("Player"))
        {
            uiTextObject.SetActive(false); // Hide the UI text object
        }
    }

    void Update()
    {
        // Check for player input
        if (uiTextObject.activeSelf && Input.GetKeyDown(KeyCode.R))
        {
            uiTextObject.SetActive(false); // Hide the UI text object
            PlayKnockingSound(); // Play the knocking sound
        }
    }

    void PlayKnockingSound()
    {
        // Play the next sound in the knocking sequence
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
    if (knockSequenceIndex == 4) // 第四次敲门声
    {
        yield return new WaitForSeconds(3); // 等待 3 秒

        // 控制灯光闪烁 4 秒
        float endTime = Time.time + 4;
        while (Time.time < endTime)
        {
            foreach (var light in lights)
            {
                light.SetActive(Random.Range(0, 2) > 0); // 随机灯光开关状态
            }
            yield return new WaitForSeconds(0.1f);
        }

        // 立即关闭所有灯光
        ToggleLights(false);

        yield return new WaitForSeconds(1); // 灯光关闭后等待 1 秒

        // 激活并移动人物模型 5 秒
        characterModel.SetActive(true); // 激活人物模型
        characterModel.transform.position = startPostion; // 设置起始位置

        float moveDuration = 5.0f; // 移动总时长
        float startTime = Time.time;

        while (Time.time < startTime + moveDuration)
        {
            float t = (Time.time - startTime) / moveDuration;
            characterModel.transform.position = Vector3.Lerp(startPostion, endPosition, t);
            yield return null;
        }

        characterModel.SetActive(false); // 移动结束后禁用人物模型

        // 禁用人物模型的瞬间打开所有灯光
        ToggleLights(true);
    }
    else
    {
        yield return new WaitForSeconds(delay); // 其他情况正常等待
    }

    if (knockSequenceIndex < knockingSounds.Length)
    {
        uiTextObject.SetActive(true); // 再次显示 UI 文本
    }
    else
    {
        // 如果已是最后一次敲门声，不再进行操作
    }
}



    void ToggleLights(bool state)
    {
        // Toggle the state of all lights
        foreach (var light in lights)
        {
            light.SetActive(state);
        }
    }
}
