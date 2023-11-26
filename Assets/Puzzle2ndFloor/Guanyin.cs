using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guanyin : MonoBehaviour
{
    public GameObject guanyinText;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            guanyinText.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        {
            guanyinText.SetActive(false);
        }
    }


}
