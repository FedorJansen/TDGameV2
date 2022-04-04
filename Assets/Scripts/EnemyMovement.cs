using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour

{
    public delegate void Alivent();
    public static Alivent alivent;
    private Transform target;
    private int waypointIndex = 0;

    public float speed = 10f;

    public int health = 2;

    void Start()
    {
        target = Waypoint.waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) <= 0.01f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if(waypointIndex >= Waypoint.waypoints.Length - 1)
        {
            
            Destroy(gameObject);
        }
        else
        {
            waypointIndex++;
            target = Waypoint.waypoints[waypointIndex];
        }
        
        
    }
}
