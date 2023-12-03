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
            NewDialogue("Player: where is here? ");
            NewDialogue("Zhang: Everything you want to know is inside the temple, come in.");
            NewDialogue("Player: Who are you? why am i here?");
            NewDialogue("Zhang: Don't waste time, come in quickly");
            NewDialogue("Zhang: You will find all the answers inside the temple"); 
            NewDialogue("Player: (talking to himself): These two people are too strange and don’t say anything. I think I'd better take a look around first.");
            NewDialogue("Player: Who are you? why am i here?");
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
        canva.gameObject.SetActive(false);
    }
}
