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
    private Vector3 startPostion = new Vector3(515, 1.4f, 89); // Start position of the character
    private Vector3 endPosition = new Vector3(515, 1.4f, -2); // End position of the character

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
        if (knockSequenceIndex == 4) // Fourth knock
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

            // turn off the light
            ToggleLights(false);

            yield return new WaitForSeconds(2); // Wait 2 seconds after turning off the light

            // Activate and move the ghost model
            characterModel.SetActive(true);
            characterModel.transform.position = startPostion;

            float moveDuration = 10.0f; // ghost movement duration changed to 10 seconds
            float startTime = Time.time;

            while (Time.time < startTime + moveDuration)
            {
                float t = (Time.time - startTime) / moveDuration;
                characterModel.transform.position = Vector3.Lerp(startPostion, endPosition, t);
                yield return null;
            }

            characterModel.SetActive(false);

            // active light 
            ToggleLights(true);
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
            // no operation after last knock
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
