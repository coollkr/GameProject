using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TP_MainMenu : MonoBehaviour
{
    public void TriggerTeleport(string targetSceneName, float delay = 0.0f)
    {
        StartCoroutine(DelayedTeleportCoroutine(targetSceneName, delay));
    }

    private IEnumerator DelayedTeleportCoroutine(string targetSceneName, float delay)
    {
        yield return new WaitForSeconds(delay); 
        SceneManager.LoadScene(targetSceneName); 
    }
}
