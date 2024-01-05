using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class currentBusToLevel : MonoBehaviour
{
    public int currentBusIndex;
    public GameObject[] busses;
    // Start is called before the first frame update
    void Start()
    {
       
        currentBusIndex = PlayerPrefs.GetInt("Selected bus", 0);
        foreach (GameObject bus in busses)
        {
            bus.SetActive(false);
        }
        busses[currentBusIndex].SetActive(true);
    }
}
