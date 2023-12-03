using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  This script controls to display of the text UI when the player comes close 
 *  to Guanyin sculpture.
 */
public class Guanyin : MonoBehaviour
{
    public GameObject guanyinText;

    // When the player goes into the range of Guanyin, display the text
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            guanyinText.SetActive(true);
        }
    }
    
    // When the player goes outside the range of Guanyin, stop displaying the text
    public void OnTriggerExit(Collider other)
    {
        {
            guanyinText.SetActive(false);
        }
    }


}
