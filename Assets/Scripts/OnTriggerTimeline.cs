using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class OnTriggerTimeline : MonoBehaviour
{
    public PlayableDirector Timeline;
    public GameObject RccCamera;
    public GameObject AnimationCamera;
    public GameObject mainbus;
    public GameObject Animationbus;
    public GameObject mainUI;
    public GameObject animationCharacter;
    public GameObject animationCharacter_2;


    // Start is called before the first frame update
    void Start()
    {
        AnimationCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            RccCamera.SetActive(false);
            AnimationCamera.SetActive(true);
            mainbus.SetActive(false);
            Animationbus.SetActive(true);
            mainUI.SetActive(false);
            Timeline.Play();
        
            GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(ResumeGame());

        }
    }
    IEnumerator ResumeGame()
    {
        yield return new WaitForSeconds(5);
        Timeline.Stop();
        RccCamera.SetActive(true);
        AnimationCamera.SetActive(false);
        mainbus.SetActive(true);
        Animationbus.SetActive(false);
        mainUI.SetActive(true);
        animationCharacter.SetActive(false);
        animationCharacter_2.SetActive(false);


    }

}
