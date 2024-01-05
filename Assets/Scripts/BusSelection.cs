using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusSelection : MonoBehaviour
{
    public GameObject mainMenuCamera;
    public GameObject busSelectionCamera;
    public GameObject mainMenuUI;
    public GameObject busMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void _mainMenuCamera()
    {
        mainMenuCamera.SetActive(true);
        busSelectionCamera.SetActive(false);
        mainMenuUI.SetActive(true);
        busMenuUI.SetActive(false);
    }
    public void _busSelectionCamera()
    {
        mainMenuCamera.SetActive(false);
        busSelectionCamera.SetActive(true);
        mainMenuUI.SetActive(false);
        busMenuUI.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
