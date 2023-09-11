using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointsMover : MonoBehaviour
{

    [SerializeField] private WayPoints waypoints;
    [SerializeField] private float moveSpeed = 5f;

    
    private Transform currentWayPoint;
    [SerializeField]
    private float distanceThreshold = 0.1f;

    // for hte  rotation target for current frame
    private Quaternion rotationgoal;

    // checkin direction agent needs to rotate towards
    private Vector3 directionToWaypoint;

    //nuz  to check how fast the agent rotates once it reaches waypoint 
    [Range(0f, 15f)]
    [SerializeField]
    private float rotateSpeed = 5f;
   


    // Start is called before the first frame update
    void Start()
    {
        //setintial pos
        currentWayPoint = waypoints.GetNextWayPoint(currentWayPoint);
        transform.position = currentWayPoint.position;

        //set next waypoint target
        currentWayPoint = waypoints.GetNextWayPoint(currentWayPoint);
        transform.LookAt(currentWayPoint);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,currentWayPoint.position,moveSpeed*Time.deltaTime);
        if(Vector3.Distance(transform.position,currentWayPoint.position) < distanceThreshold)
        {
            currentWayPoint = waypoints.GetNextWayPoint(currentWayPoint);
            //transform.LookAt(currentWayPoint);
        }
        RotateTowardsWaypoint();
    }

    // now here check whejether it will slowly rotate agent towards current waypoint it is moving towards

    private void RotateTowardsWaypoint()
    {
        directionToWaypoint = (currentWayPoint.position - transform.position).normalized;
        rotationgoal = Quaternion.LookRotation(directionToWaypoint);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationgoal, rotateSpeed * Time.deltaTime);
    }
}
