using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//script to check if player read all the things in cutscene and press F to go to next level. 
public class nextscene : MonoBehaviour
{
    // Start is called before the first frame update

    public string next;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene(next);
        }
    }
    
    
}
