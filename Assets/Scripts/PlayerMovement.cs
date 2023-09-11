using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerMovement : MonoBehaviour
{
    public  LineRenderer Lr;


    // Start is called before the first frame update
    void Start()
    {

     Lr = GetComponent<LineRenderer>();

      
     
    
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetMouseButtonDown(0))
        // {
        // Ray moveposition = Camera.main.ScreenPointToRay(Input.mousePosition);
        //   if(Physics.Raycast(moveposition,out var hitinfo))
        //  {
        //    Debug.Log("ray hit");


        //  }
        //  }

       
    }

    
}
