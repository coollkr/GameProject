using System;
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
    public float chaseDis = 60.0f;
    public float patrolSpeed = 5.46f;
    public float chasingSpeed = 7.5f;
    public Collider safesapce;
    private Transform[] waypoints;
    private int currentWaypoint;
    private NavMeshAgent nav;
    private Boolean chasing;


    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        chasing = false;
  
        if (path != null)
        {
            waypoints = path.getWaypoints();

            if (waypoints != null && waypoints.Length > 0)
            {
                currentWaypoint = 0;
                nav.enabled = true;
                nav.speed = patrolSpeed;
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
        float disFromPlayer = Vector3.Distance(transform.position, player.position);

        if (chasing == true)
        {
            if(disFromPlayer > chaseDis || safesapce.bounds.Contains(player.position))
            {
                chasing = false;
                FindNearestWaypoint();
                nav.SetDestination(waypoints[currentWaypoint].position);
            }
            else
            {
                nav.SetDestination(player.position);
                nav.speed = chasingSpeed;
            }
        }
        else
        {
            if(disFromPlayer < chaseDis && !safesapce.bounds.Contains(player.position))
            {
                chasing = true;
                nav.SetDestination(player.position);
                nav.speed = chasingSpeed;
            }
            else
            {
                float disFromWaypoint = Vector3.Distance(transform.position, waypoints[currentWaypoint].position);
                Debug.Log("This is right. BUt the distance is " + disFromWaypoint);
                if ( !nav.pathPending && disFromWaypoint < 3.0f)
                {
                    NextWaypoint();
                }
            }
        }
    }

    void NextWaypoint()
    {
        currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        nav.SetDestination(waypoints[currentWaypoint].position);
        Debug.Log(currentWaypoint);
    }

    void FindNearestWaypoint()
    {
        int shortestIndex = 0;
        float temp = Vector3.Distance(transform.position, waypoints[shortestIndex].position);
        for(int i = 1; i < waypoints.Length; i++)
        {
            if(temp >= Vector3.Distance(transform.position, waypoints[i].position))
            {
                temp = Vector3.Distance(transform.position, waypoints[i].position);
                shortestIndex = i;
            }
        }

        currentWaypoint = shortestIndex; 
    }
}
