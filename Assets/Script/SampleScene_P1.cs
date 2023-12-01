using UnityEngine;
using System.Collections;
using TMPro;

public class Candle : MonoBehaviour
{
    public Light candleLight; 
    public TextMeshProUGUI closeCandleText; 
    public TextMeshProUGUI lightingText; 
    public float activationDistance = 5f; 
    private bool isCandleLit = false; 
    private GameObject player; 

    void Start()
    {
        candleLight.enabled = false; 
        player = GameObject.FindGameObjectWithTag("Player"); 
        closeCandleText.gameObject.SetActive(false); 
    }

    void Update()
    {
        if (!isCandleLit)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance <= activationDistance)
            {
                closeCandleText.gameObject.SetActive(true); 
                if (Input.GetKeyDown(KeyCode.R))
                {
                    StartCoroutine(LightCandleRoutine());
                }
            }
            else
            {
                closeCandleText.gameObject.SetActive(false); 
            }
        }
    }

    public bool IsCandleLit
    {
        get { return isCandleLit; }
    }

    IEnumerator LightCandleRoutine()
    {
        closeCandleText.gameObject.SetActive(false); 
        lightingText.text = "Lighting the candle";
        yield return new WaitForSeconds(2);

        for (int i = 3; i > 0; i--)
        {
            lightingText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }

        lightingText.text = "The candles have been lit.";
        candleLight.enabled = true; 
        isCandleLit = true;
        yield return new WaitForSeconds(2);
        lightingText.text = ""; 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            closeCandleText.gameObject.SetActive(true); 
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            closeCandleText.gameObject.SetActive(false); 
            lightingText.text = ""; 
        }
    }
}
