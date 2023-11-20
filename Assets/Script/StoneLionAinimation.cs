using UnityEngine;
using System.Collections;

public class RotateStoneLion : MonoBehaviour
{
    private bool isPlayerNear = false;
    public float totalRotation =0f;
    public float rotationSpeed = 1f;

    private bool isRotating = false;
    public GameObject stoneLion;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.R)&& !isRotating)
        {
            StartCoroutine(RotateObject());
        }
    }

    IEnumerator RotateObject()
    {
        isRotating = true;

        Quaternion startRotation = stoneLion.transform.rotation;
        float targetRotation = totalRotation + 90f;
        Quaternion targetRotationQuaternion = Quaternion.Euler(0, targetRotation, 0);

        float elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            stoneLion.transform.rotation = Quaternion.Lerp(startRotation, targetRotationQuaternion, elapsedTime);
            elapsedTime += Time.deltaTime * rotationSpeed;
            yield return null;
        }

        stoneLion.transform.rotation = targetRotationQuaternion;
        totalRotation = targetRotation % 360f; 

        isRotating = false;
    }

}
