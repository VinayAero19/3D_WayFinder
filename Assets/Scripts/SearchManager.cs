using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class SearchManager : MonoBehaviour
{
    
    public GameObject ContentHolder;
    public GameObject[] elements;
    public GameObject searchbar;
    public int totalElements;
    private Transform searchedLocation;


    public NavMeshAgent agent;
    public SearchManager getLocation;
    public int Totaldest;
    public GameObject[] destination;
    public GameObject locationHolder;

    [SerializeField]
    private GameObject marker;
    [SerializeField]
    private Transform visualthings;
    [SerializeField]
    private GameObject pointer;

    private Vector3 finaldestination;

    public PlayerMovement pm;

     private Vector3 final;

     private List<Vector3> point;

    private bool isreached = false;

    // Start is called before the first frame update
    void Start()
    {


        totalElements = ContentHolder.transform.childCount;
        elements = new GameObject[totalElements];
        for (int i = 0; i < totalElements; i++)
        {
            elements[i] = ContentHolder.transform.GetChild(i).gameObject;
        }

        Totaldest = locationHolder.transform.childCount;
        destination = new GameObject[Totaldest];
        for (int i = 0; i < destination.Length; i++)
        {
            destination[i] = locationHolder.transform.GetChild(i).gameObject;
        }

       pm.Lr.startWidth = 1f;
       pm.Lr.endWidth = 1f;
       pm.Lr.positionCount = 0;
    }

    private void Update()
    {
        
        if(agent.hasPath)
        {
            DisplayDestination();
        }
       

       
    }
    public void search()
    {
        string searchtext = searchbar.GetComponent<TMP_InputField>().text;

      

        foreach (GameObject ele in elements)
        {
            string name = ele.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
            if (name.ToLower().Contains(searchtext.ToLower()))
                ele.SetActive(true);
            else
                ele.SetActive(false);

        

        }

        



        foreach (GameObject dest in destination)
        {
            

            if (searchtext.ToLower() == dest.gameObject.name.ToLower())
            {
                final = dest.gameObject.transform.position;
                agent.SetDestination(dest.gameObject.transform.position);
                marker.transform.SetParent(visualthings);
                pointer.gameObject.SetActive(true);
                marker.transform.position = final + new Vector3(0, 0.1f, 0f);
               
                pointer.transform.position  = final+ new Vector3(0,4.5f,0f);

                Debug.Log(agent.transform.position);
                Debug.Log(final);
               

               
            }
        }


      
    }

   


    private void DisplayDestination()
    {
        if (agent.path.corners.Length < 2) return;
       int i=1;
        while(i < agent.path.corners.Length)
        {
            pm.Lr.positionCount = agent.path.corners.Length;
            point = agent.path.corners.ToList();
            for(int j=0; j<point.Count; j++)  
            {
                pm.Lr.SetPosition(j,point[j]);
            }
            i++;

           

        }
    }
    }

