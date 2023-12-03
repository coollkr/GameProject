using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthEffectController : MonoBehaviour
{
    public Image healthEffectImage; 
    public float effectDuration = 1.0f; 

    void Start()
    {
        healthEffectImage.enabled = false;
        healthEffectImage.color = new Color(1, 0, 0, 0); 
    }

    public void TriggerHealthEffect()
    {
        StartCoroutine(ShowHealthEffect());
    }

    private IEnumerator ShowHealthEffect()
    {
        healthEffectImage.enabled = true;

       
        float halfDuration = effectDuration / 2;
        for (float t = 0; t < halfDuration; t += Time.deltaTime)
        {
            float normalizedTime = t / halfDuration; 
            healthEffectImage.color = new Color(1, 0, 0, normalizedTime);
            yield return null;
        }

        healthEffectImage.color = new Color(1, 0, 0, 1); 

      
        for (float t = 0; t < halfDuration; t += Time.deltaTime)
        {
            float normalizedTime = t / halfDuration; 
            healthEffectImage.color = new Color(1, 0, 0, 1 - normalizedTime);
            yield return null;
        }

        healthEffectImage.color = new Color(1, 0, 0, 0); 
        healthEffectImage.enabled = false;
    }
}
