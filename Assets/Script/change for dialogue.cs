using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script to read the dialogue.
public class changefordialogue : MonoBehaviour
{
    private int index = 2;
    void Update()
    {   
        //left click to continue reading the dialogue.
        if (Input.GetMouseButtonDown(0) && transform.childCount > 1)
        {
            if(mainplayer.dialogue)
            {
                transform.GetChild(index).gameObject.SetActive(true);
                index += 1;
                if (transform.childCount == index)
                {
                    index = 2;
                    mainplayer.dialogue = false;
                    
                }
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
