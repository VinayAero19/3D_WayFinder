using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{

    [Range(0f, 2f)]
    [SerializeField] private float wayPointsSize = 1f;

    [Header("Path Settings")]
    //sets path to be in loop
    [SerializeField]
    private bool canLoop = true;

    //sets agent to move forward and backwards
    [SerializeField]
    private bool ismovingForward = true;
    private void OnDrawGizmos()
    {
        foreach(Transform t in transform)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(t.position, wayPointsSize);
        }
        Gizmos.color = Color.red;

        for(int i=0;i<transform.childCount-1;i++)
        {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i+1).position);
        }

        //if path is set to loop then draw a line between first and last waypoint
        if(canLoop)
        {
            Gizmos.DrawLine(transform.GetChild(transform.childCount - 1).position, transform.GetChild(0).position);
        }
     
    }

    //will get the correct next waypoint based on direction currently travelling
    public Transform GetNextWayPoint(Transform currentWayPoint)
    {
        if(currentWayPoint == null)
        {
            return transform.GetChild(0);
         
        }
        //stores the index of current waypoint 

        int currentIndex = currentWayPoint.GetSiblingIndex();

        //stores the index of next waypoint to travel towards 

        int nextIndex = currentIndex;

        //agent is moving forward on the opath

        if(ismovingForward)
        {
            nextIndex += 1;

            //if the next waypoint index is equal to count of childrem/ waypoint then it is already at the last waypoint 
            //check if path is set to loop & return first way point as current waypoint othws substract 1
            //from nxet index which will rerturn the same waypoint the agent is currently at
            // which will cause it to stop moving since it s alrdy there. 

            if (nextIndex == transform.childCount)
            {
               if(canLoop == true)
                {
                    nextIndex = 0;
                }
                else
                {
                    nextIndex-= 1;
                }
            }
        }

        //agent is moving backwards on paath

        else
        {
            nextIndex -= 1;


            // if next index equals to zero then you are already at first way point,check if the path is set 
            // to loop if so then return the last waypoint otherwise we add 1 to the nextindex whic will returm the current
            //waypoint you are already at which will cause agent to stop since it is already there.
            if(nextIndex < 0)
            {
                if(canLoop == true)
                {
                    nextIndex = transform.childCount - 1;
                }
                else
                {
                    nextIndex += 1;

                }
            }
        }

        // returb the  waypoint has Index of Nextindex
        return transform.GetChild(nextIndex);
    }
}
