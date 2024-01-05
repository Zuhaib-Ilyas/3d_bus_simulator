using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinTrigger : MonoBehaviour
{
    public GameObject Coin;
    public float coinRotateSpeed = 40f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, coinRotateSpeed * Time.deltaTime);
    }
   
}
