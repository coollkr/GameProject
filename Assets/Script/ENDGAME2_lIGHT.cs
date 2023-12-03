using UnityEngine;

public class LightIntensityController : MonoBehaviour
{
    private Light lightComponent;
    public float maxIntensity = 10f;
    private float intensityIncrement;

    void Awake()
    {
        lightComponent = GetComponent<Light>();
        intensityIncrement = (maxIntensity - lightComponent.intensity) / 5f; 
    }

    void Update()
    {
        if (lightComponent.intensity < maxIntensity)
        {
            lightComponent.intensity += intensityIncrement * Time.deltaTime;
        }
    }
}
