using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPath : MonoBehaviour 
{ 
    private int NumOfWaypoints;
    private Transform[] waypoints;
    
    // Start is called before the first frame update
    void Awake()
    {
        NumOfWaypoints = transform.childCount;
        waypoints = new Transform[NumOfWaypoints];

        for(int i = 0; i < transform.childCount; i++)
        {
            waypoints[i] = transform.GetChild(i);
        }

        Debug.Log(waypoints.Length);

    }

    // Update is called once per frame
    public Transform[] getWaypoints()
    {
        return waypoints;
    }


}
