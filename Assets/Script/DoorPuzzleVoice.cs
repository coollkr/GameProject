using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;


public class DoorPuzzleVoice : MonoBehaviour
{
    public GameObject uiTextObject; 
    public AudioClip[] knockingSounds; 
    private AudioSource audioSource; 
    private int knockSequenceIndex = 0; 
    public List<GameObject> lights;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        uiTextObject.SetActive(false); 
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
        if (knockSequenceIndex == 4) // Fourth knock.
        {
            yield return new WaitForSeconds(3); // Wait until the recording reaches the 3rd second

            // For the next 4 seconds, perform a random on/off operation for each light
            float endTime = Time.time + 4;
            while (Time.time < endTime)
            {
                foreach (var light in lights)
                {
                    light.SetActive(Random.Range(0, 2) > 0); // Randomize the state of each light
                }
                yield return new WaitForSeconds(0.1f); // wait
            }

            yield return new WaitForSeconds(delay - 7); // Waiting for the remaining recording playback time
        }
        else
        {
            yield return new WaitForSeconds(delay); // Normal wait in other cases
        }

        if (knockSequenceIndex < knockingSounds.Length)
        {
            uiTextObject.SetActive(true); // The UI of R is displayed again after the sound is played.
        }
        else
        {
            ToggleLights(false); // Turn off all lights.
            yield return new WaitForSeconds(5); // Wait five seconds.
            ToggleLights(true); // Turn all the lights back on.
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
