
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoorPuzzleVoice : MonoBehaviour
{
    public GameObject uiTextObject; 
    public AudioClip[] knockingSounds; // Array of knocking sound clips.
    private AudioSource audioSource; // AudioSource component for playing sounds.
    private int knockSequenceIndex = 0; // Index to track the current knock in the sequence.
    public List<GameObject> lights; // List of light objects to be controlled.

    public GameObject characterModel; 
    private Vector3 startPostion = new Vector3(515, 1.4f, 89); // ghost start location
    private Vector3 endPosition = new Vector3(515, 1.4f, -2); // destinate locaiton
    private mouselook cameraScript; // mouselook Script references
    public GameObject specialLight; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
        uiTextObject.SetActive(false); 

            if (specialLight != null)
    {
        specialLight.SetActive(false);
    }

        // 尝试找到主角上的 mouselook 脚本
        GameObject mainCamera = GameObject.FindWithTag("MainCamera"); 
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
        if (other.CompareTag("Player") && knockSequenceIndex < knockingSounds.Length)
        {
            uiTextObject.SetActive(true); 
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiTextObject.SetActive(false); 
        }
    }

    void Update()
    {
        if (uiTextObject.activeSelf && Input.GetKeyDown(KeyCode.R))
        {
            uiTextObject.SetActive(false);
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
        if (knockSequenceIndex == 4) // The Fourth Knock
        {
            yield return new WaitForSeconds(2); // wait 2 seconds

            // Controls light blinking for 4 seconds
            float endTime = Time.time + 4;
            while (Time.time < endTime)
            {
                foreach (var light in lights)
                {
                    light.SetActive(Random.Range(0, 2) > 0);
                }
                yield return new WaitForSeconds(0.1f);
            }

            // Turn off the lights.
            ToggleLights(false);

            yield return new WaitForSeconds(2); // Wait 2 seconds after turning off the light

            // Activate and move the character model
            characterModel.SetActive(true);
            cameraScript.SetFollowCharacterModel(true); // Enable Lens Following
            characterModel.transform.position = startPostion;

            float moveDuration = 3.0f; // ghost move time
            float startTime = Time.time;

            while (Time.time < startTime + moveDuration)
            {
                float t = (Time.time - startTime) / moveDuration;
                characterModel.transform.position = Vector3.Lerp(startPostion, endPosition, t);
                yield return null;
            }

            cameraScript.SetFollowCharacterModel(false); // disabale lens folloing 
            characterModel.SetActive(false);

            yield return new WaitForSeconds(1); // Wait 1 second after disabling camera follow

            // Turn off the ghost model and turn on all the lights at the same time
            ToggleLights(true);
            if (specialLight != null)
        {
            yield return new WaitForSeconds(0.5f); 
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
            // No operation after the last knock
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
