using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCstricpt : MonoBehaviour
{
    //Start is called before the first frame update
    public GameObject d_template;
    public GameObject canva;
    bool player_detection = false;
    void Update()
    {
        if (player_detection && Input.GetKeyDown(KeyCode.F) && !mainplayer.dialogue)
        {
            canva.SetActive(true);
            mainplayer.dialogue = true;
            NewDialogue("Hi.");
            NewDialogue("My name is Kairui Liang.");
            NewDialogue("Nice to meet you!");
            canva.transform.GetChild(1).gameObject.SetActive(true);
        }
        
    }

    void NewDialogue(string text)
    {
        GameObject template_clone = Instantiate(d_template, d_template.transform);
        template_clone.transform.parent = canva.transform;
        template_clone.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "maincharacter")
        {
            player_detection = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        player_detection = false;
    }
}
