using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class GhostAI : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public GhostPath path;
    public float chaseDis = 100.0f;
    private Transform[] waypoints;
    private int currentWaypoint;
    private NavMeshAgent nav;


    void Start()
    {
        nav = GetComponent<NavMeshAgent>();

  
        if (path != null)
        {
            waypoints = path.getWaypoints();

            if (waypoints != null && waypoints.Length > 0)
            {
                currentWaypoint = 0;
                nav.enabled = true;
                nav.SetDestination(waypoints[currentWaypoint].position);
            }
            else
            {
                Debug.LogError("Waypoints array is not initialized or empty.");
            }
        }
        else
        {
            Debug.LogError("Path variable is not assigned.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float playerDis = Vector3.Distance(transform.position, player.position);

        if (playerDis < chaseDis)
        {
            nav.SetDestination(player.position);
        }

        else
        {
            if (!nav.pathPending && nav.remainingDistance < 0.5f)
            {
                nextWaypoint();
            }
            //else if(!nav.pathPending && nav.remainingDistance >= 0.5f)
            //{
            //    var sortedWaypoints = waypoints.OrderBy(dis => Vector3.Distance(transform.position, dis.position)).ToArray();
            //    nav.SetDestination(sortedWaypoints[0].position);
            //}
        }
    }

    void nextWaypoint()
    {
        nav.SetDestination(waypoints[currentWaypoint].position);
        currentWaypoint = (currentWaypoint + 1) % waypoints.Length; 
    }

}
