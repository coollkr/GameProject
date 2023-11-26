using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LuopanPoint : MonoBehaviour
{

    public GameObject puzzleText;
    private bool playerInRange;
    public InventoryManager inventoryManager;
    public int itemValue;
    public GameObject successText;
    public GameObject failureText;
    public Color successColor;
    private bool isSolved;
    private Light pointLight;



    public void Start()
    {
        playerInRange = false;
        isSolved = false;
        pointLight = GetComponent<Light>();
    }

    public void Update()
    {
        string keyPressed = "NO";
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

        if (playerInRange)
        {
            if (keyPressed.Equals("1"))
            {
                if (itemNum >= 1)
                {
                    int usingItem = items[0].value;

                    Debug.Log("Prssed 1, ussing item = " + usingItem);
                    Debug.Log("This Item = " + itemValue);

                    if (itemValue == usingItem)
                    {
                        Debug.Log("判定成功");
                        StartCoroutine(ShowSuccessText());
                        isSolved = true;
                        ChangeLightColor();
                        failureText.SetActive(false);
                        puzzleText.SetActive(false);
                        items.RemoveAt(0);
                    }
                    else
                    {
                        StartCoroutine(ShowFailureText());
                    }
                }
            }
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

    IEnumerator ShowFailureText()
    {
        failureText.SetActive(true);
        Debug.Log("Showing Failure Text");

        yield return new WaitForSeconds(2.0f);

        failureText.SetActive(false);
        Debug.Log("Showing Success Text");
    }

    IEnumerator ShowSuccessText()
    {
        successText.SetActive(true);
        Debug.Log("Showing Success Text");

        yield return new WaitForSeconds(2.0f);
        Debug.Log("Showing Success Text");
        successText.SetActive(false);
    }

    void ChangeLightColor()
    {
        pointLight.color = successColor;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isSolved)
        {
            puzzleText.SetActive(true);
            playerInRange = true;
        }

    }
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
