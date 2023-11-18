using UnityEngine;
using System.Collections;

public class RotateStoneLion : MonoBehaviour
{
    private bool isPlayerNear = false;
    // 旋转的目标角度
    public float totalRotation =0f;
    // 旋转速度
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
            // 启动旋转动画
            StartCoroutine(RotateObject());
        }
    }

    IEnumerator RotateObject()
    {
        isRotating = true;

        // 获取当前物体的旋转
        Quaternion startRotation = stoneLion.transform.rotation;
        // 计算目标旋转
        float targetRotation = totalRotation + 90f;
        Quaternion targetRotationQuaternion = Quaternion.Euler(0, targetRotation, 0);

        // 插值旋转
        float elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            stoneLion.transform.rotation = Quaternion.Lerp(startRotation, targetRotationQuaternion, elapsedTime);
            elapsedTime += Time.deltaTime * rotationSpeed;
            yield return null;
        }

        // 确保物体准确达到目标角度
        stoneLion.transform.rotation = targetRotationQuaternion;
        totalRotation = targetRotation % 360f; // 确保总旋转角度不超过360度

        isRotating = false;
    }

}
