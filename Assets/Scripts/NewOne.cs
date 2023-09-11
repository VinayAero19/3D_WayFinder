
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class NewOne : MonoBehaviour
{
    public GameObject elementContainer;
    public GameObject[] elements;
    public GameObject searchbar;
    public int totalElements;
    private Transform searchedLocation;

    public NavMeshAgent agent;
    public int Totaldest;
    public GameObject[] destination;
    public GameObject destinationContainer;

    void Start()
    {
        totalElements = elementContainer.transform.childCount;
        elements = new GameObject[totalElements];
        for (int i = 0; i < totalElements; i++)
        {
            elements[i] = elementContainer.transform.GetChild(i).gameObject;
        }

        Totaldest = destinationContainer.transform.childCount;
        destination = new GameObject[Totaldest];
        for (int i = 0; i < destination.Length; i++)
        {
            destination[i] = destinationContainer.transform.GetChild(i).gameObject;
        }
    }

    public void Search()
    {
        string searchtext = searchbar.GetComponent<TMP_InputField>().text.ToLower(); 

        foreach (GameObject ele in elements)
        {
            TextMeshProUGUI textComponent = ele.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            string elementText = textComponent.text.ToLower(); 

            if (elementText.Length >= searchtext.Length && elementText.Substring(0, searchtext.Length) == searchtext.ToString())
            {
                ele.SetActive(true);
                searchedLocation = ele.transform;
                
            }
            else
            {
                ele.SetActive(false);
            }
        }
        foreach (GameObject dest in destination)
                {
                    if (dest.gameObject.name == dest.gameObject.name.Substring(0, searchtext.Length))
                    {
                        Debug.Log("Name match: " + dest.gameObject.name);
                        Debug.Log("Transform found: " + dest.transform.position);
                        agent.SetDestination(dest.transform.position);
                    }
           
        }
        

        
    }
}

