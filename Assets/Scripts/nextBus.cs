using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class nextBus : MonoBehaviour

{
    public int currentBusIndex;
    public GameObject[] busModels;
    public BusBluePrints[] busses;
    public Button buyButton;
    public Button _PlayButton;

    // Start is called before the first frame update
    void Start()
    {
        foreach(BusBluePrints  bus in busses)
        {
            if (bus.price == 0)
                bus.isUnlocked = true;

            else
                bus.isUnlocked = PlayerPrefs.GetInt(bus.name, 0) == 0 ? false : true;   
        }
            





        PlayerPrefs.SetInt("Selected bus", 0);
        currentBusIndex = PlayerPrefs.GetInt("Selected bus",0);
        foreach (GameObject bus in busModels)
        {
            bus.SetActive(false);
        }
        busModels[currentBusIndex].SetActive(true);
    }
    public void ChangeNext()
    {
        busModels[currentBusIndex].SetActive(false);
        currentBusIndex++;
        if (currentBusIndex == busModels.Length)
        {
            currentBusIndex =0;
        }

        busModels[currentBusIndex].SetActive(true);
        BusBluePrints b = busses[currentBusIndex];
        if (!b.isUnlocked)
            return;
        PlayerPrefs.SetInt("Selected bus", currentBusIndex);

    }

    public void ChangePrevious()
    {
        busModels[currentBusIndex].SetActive(false);
        currentBusIndex--;
        if (currentBusIndex == -1)
        {
            currentBusIndex = 0;
        }

        busModels[currentBusIndex].SetActive(true);
        BusBluePrints b = busses[currentBusIndex];
        if (!b.isUnlocked)
            return;
        PlayerPrefs.SetInt("Selected bus", currentBusIndex);

    }
     public void UnlockBus()
    {
        BusBluePrints b = busses[currentBusIndex];
        PlayerPrefs.SetInt(b.name,1);
        PlayerPrefs.SetInt("Selected bus", currentBusIndex);
        b.isUnlocked = true;
        PlayerPrefs.SetInt("Cash",PlayerPrefs.GetInt("Cash",0)-b.price);
    }




    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }
    // Update is called once per frame
    void Update()
    {
        updateUI();
    }

    void updateUI()
    {
        BusBluePrints b = busses[currentBusIndex];
        if (b.isUnlocked)
        {
            buyButton.gameObject.SetActive(false);
            _PlayButton.interactable = true;
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy" + b.price;
            if (b.price < PlayerPrefs.GetInt("Cash", 0))
            {
                buyButton.interactable = true;
                _PlayButton.interactable = false;
            }
            else
            {
                buyButton.interactable = false;
                _PlayButton.interactable = false;
            }
        }
    }

}
