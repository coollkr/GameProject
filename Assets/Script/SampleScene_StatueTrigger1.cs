using UnityEngine;

public class TriggerController : MonoBehaviour
{
    public StatueController[] statues; 
    public GameObject exitTrigger; // Trigger at the door.
    public GameObject innerTrigger; // Trigger inside the room

    void Start()
    {
        exitTrigger.SetActive(false);
        innerTrigger.SetActive(true); 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject == innerTrigger)
            {
                // Activate all stone statues
                foreach (StatueController statue in statues)
                {
                    statue.Activate();
                }
                exitTrigger.SetActive(true); 
                innerTrigger.SetActive(false); 
            }
            else if (gameObject == exitTrigger)
            {
                foreach (StatueController statue in statues)
                {
                    statue.Deactivate();
                }
            }
        }
    }
}
