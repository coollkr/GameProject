using UnityEngine;

public class StatueController : MonoBehaviour
{
    private Transform player; 
    public bool isActive = false; 

    void Update()
    {
        if (isActive)
        {
            if (player == null)
            {
                FindPlayer(); 
            }
            else
            {
                RotateTowardsPlayer();
            }
        }
    }

    private void FindPlayer()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    private void RotateTowardsPlayer()
    {
        Vector3 direction = player.position - transform.position;
        direction.y = 0; 
        transform.rotation = Quaternion.LookRotation(direction);
    }

    public void Activate()
    {
        isActive = true;
    }

    public void Deactivate()
    {
        isActive = false;
    }
}
