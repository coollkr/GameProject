using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//this is a NPC stricpt to check if the player is around NPC and player can also talk with NPC with dialogue
public class NPCscript : MonoBehaviour
{
    //Start is called before the first frame update
    public GameObject d_template;
    public GameObject canva;
    bool player_detection = false;
    void Update()
    {
        //check if F is pressed and if player is around the NPC.
        if (player_detection && Input.GetKeyDown(KeyCode.F) && !mainplayer.dialogue)
        {
            canva.SetActive(true);
            mainplayer.dialogue = true;
            NewDialogue("Player: where is here? ");
            NewDialogue("Zhang: Everything you want to know is inside the temple, come in.");
            NewDialogue("Player: Who are you? why am i here?");
            NewDialogue("Zhang: Don't waste time, come in quickly");
            NewDialogue("Zhang: You will find all the answers inside the temple"); 
            NewDialogue("Player: (talking to himself): This people is too strange and don’t say anything. I think I'd better take a look around first.");
            NewDialogue("Player: Who are you? why am i here?");
            canva.transform.GetChild(1).gameObject.SetActive(true);
        }
        
    }
    
    // a method to clone the dialogue template to display the text.
    void NewDialogue(string text)
    {
        GameObject template_clone = Instantiate(d_template, d_template.transform);
        template_clone.transform.parent = canva.transform;
        template_clone.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
    }

    // trigger for player detection.
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
