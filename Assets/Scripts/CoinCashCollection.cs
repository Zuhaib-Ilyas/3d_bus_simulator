using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCashCollection : MonoBehaviour
{
    public static int cashAmount;
    public TextMeshProUGUI cash;
    public AudioSource coinSound;

    // Start is called before the first frame update
    void Start()
    {
        cashAmount = 1000;
        if (PlayerPrefs.HasKey("Cash"))
        {
            cashAmount = PlayerPrefs.GetInt("Cash");
        }
        else
        {

        }
        cash.text = "CASH : " + cashAmount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cash"))
        {
            Destroy(other.gameObject);
            
            cashAmount += 10;
            coinSound.Play();
            PlayerPrefs.SetInt("Cash",cashAmount);
            cash.text = "CASH : " + cashAmount;
        }
    }
}
