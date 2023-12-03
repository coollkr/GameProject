using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script is attached to the candle on the Luopan
 * It is used to display the puzzle text and determine if the user used the correct item
 */
public class LuopanPoint : MonoBehaviour
{
    public GameObject puzzleText;       // indicate the player to use an item 
    private bool playerInRange;         
    public InventoryManager inventoryManager; 
    public int itemValue;           // set the correct item that should placed at the point
    public GameObject successText;  // suggest the player when solving the puzzle
    public GameObject failureText;  // suggest the player when failing the puzzle
    public Color successColor;      // the color being changed when completing the puzzle 
    private bool isSolved;          // flag
    private Light pointLight;       // the light the puzzle is attached to

    public void Start()
    {
        playerInRange = false;
        isSolved = false;
        pointLight = GetComponent<Light>();
    }

    public void Update()
    {
        string keyPressed = "NO";    // change the input string to default as it won't change itself
        // save the user input 
        if (Input.GetKeyDown(KeyCode.Alpha1))          
        {
            keyPressed = "1";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            keyPressed = "2";
        }else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            keyPressed= "3";
        }else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            keyPressed = "4";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            keyPressed = "5";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            keyPressed = "6";
        }
        
        
        List<UsableItem> items = inventoryManager.getItems();
        int itemNum = inventoryManager.getItemNumber();
        // if the player is in the puzzle range
        if (playerInRange)
        {
            // if key "1" is pressed 
            if (keyPressed.Equals("1"))
            {
                if (itemNum >= 1)
                {
                    // get the first item from the list
                    int usingItem = items[0].value;

                    Debug.Log("Prssed 1, ussing item = " + usingItem);
                    Debug.Log("This Item = " + itemValue);

                    // if the used item value is correct
                    if (itemValue == usingItem)
                    {
                        Debug.Log("判定成功");
                        StartCoroutine(ShowSuccessText()); // show the success text for a period of time
                        isSolved = true;                   // change the flag
                        ChangeLightColor();                // change the color of the light
                        failureText.SetActive(false);      // close the failure text if it still exists
                        puzzleText.SetActive(false);       // close the puzzle text
                        items.RemoveAt(0);                 // remove the item from the list
                    }
                    else
                    {
                        StartCoroutine(ShowFailureText()); // show failure text if this is not the right item
                    }
                }
            }
            // Same logic as "1"
            else if (keyPressed.Equals("2"))
            {
                if (itemNum >= 2)
                {
                    int usingItem = items[1].value;
                    Debug.Log(keyPressed + "Keypressed");
                    Debug.Log("Prssed 2, ussing item = " + usingItem);
                    Debug.Log("This Item = " + itemValue);
                    if (itemValue == usingItem)
                    {
                        Debug.Log("判定成功");
                        StartCoroutine(ShowSuccessText());
                        isSolved = true;
                        ChangeLightColor();
                        failureText.SetActive(false);
                        puzzleText.SetActive(false);
                        items.RemoveAt(1);
                    }
                    else
                    {
                        StartCoroutine(ShowFailureText());
                    }
                }

            }
            // Same logic as "1"
            else if (keyPressed.Equals("3"))
            {
                if (itemNum >= 3)
                {
                    int usingItem = items[2].value;
                    if (itemValue == usingItem)
                    {
                        StartCoroutine(ShowSuccessText());
                        isSolved = true;
                        ChangeLightColor();
                        failureText.SetActive(false);
                        puzzleText.SetActive(false);
                        items.RemoveAt(2);
                    }
                    else
                    {
                        StartCoroutine(ShowFailureText());
                    }
                }
            }
            // Same logic as "1"
            else if (keyPressed.Equals("4"))
            {
                if (itemNum >= 4)
                {
                    int usingItem = items[3].value;
                    if (itemValue == usingItem)
                    {
                        StartCoroutine(ShowSuccessText());
                        isSolved = true;
                        ChangeLightColor();
                        failureText.SetActive(false);
                        puzzleText.SetActive(false);
                        items.RemoveAt(3);
                    }
                    else
                    {
                        StartCoroutine(ShowFailureText());
                    }
                }
            }
            // Same logic as "1"
            else if (keyPressed.Equals("5"))
            {
                if (itemNum >= 5)
                {
                    int usingItem = items[4].value;
                    if (itemValue == usingItem)
                    {
                        StartCoroutine(ShowSuccessText());
                        isSolved = true;
                        ChangeLightColor();
                        failureText.SetActive(false);
                        puzzleText.SetActive(false);
                        items.RemoveAt(4);
                    }
                    else
                    {
                        StartCoroutine(ShowFailureText());
                    }
                }
            }
            // Same logic as "1"
            else if (keyPressed.Equals("6"))
            {
                if (itemNum >= 6)
                {
                    int usingItem = items[5].value;
                    if (itemValue == usingItem)
                    {
                        StartCoroutine(ShowSuccessText());
                        isSolved = true;
                        ChangeLightColor();
                        failureText.SetActive(false);
                        puzzleText.SetActive(false);
                        items.RemoveAt(5);
                    }
                    else
                    {
                        StartCoroutine(ShowFailureText());
                    }
                }
            }
        }
        
    }

    // Show the failure text for 2 seconds when failed
    IEnumerator ShowFailureText()
    {
        failureText.SetActive(true);
        Debug.Log("Showing Failure Text");

        yield return new WaitForSeconds(2.0f);

        failureText.SetActive(false);
        Debug.Log("Showing Success Text");
    }

    // Show the failure text for 2 seconds when puzzle solved
    IEnumerator ShowSuccessText()
    {
        successText.SetActive(true);
        Debug.Log("Showing Success Text");

        yield return new WaitForSeconds(2.0f);
        Debug.Log("Showing Success Text");
        successText.SetActive(false);
    }

    // change the color of the candle light when succeed 
    void ChangeLightColor()
    {
        pointLight.color = successColor;
    }

    // indicate the player to use an item
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isSolved)
        {
            puzzleText.SetActive(true);
            playerInRange = true;
        }

    }
    // turn off the reminder of the puzzle
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            puzzleText.SetActive(false);
            playerInRange = false;
        }
    }

    public bool IsSolved()
    {
        return isSolved;
    }
}
