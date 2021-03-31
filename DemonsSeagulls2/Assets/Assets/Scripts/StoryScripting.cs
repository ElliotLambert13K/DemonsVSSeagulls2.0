using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryScripting : MonoBehaviour
{
    public GameObject StoryUI;
    private bool StoryUIOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        StoryUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        
    }
}
