using UnityEngine;

public class Scene1Manager : MonoBehaviour
{
    public Transform characterModel; // 拖拽 Scene1 中的 characterModel 到这里

    void Start()
    {
        // 查找包含 mouselook 脚本的主摄像机
        mouselook cameraLookScript = FindObjectOfType<mouselook>();
        if (cameraLookScript != null && characterModel != null)
        {
            cameraLookScript.characterModel = characterModel;
            Debug.Log("Character model set in mouselook script");
        }
        else
        {
            Debug.LogError("mouselook script or character model not found");
        }
    }
}
