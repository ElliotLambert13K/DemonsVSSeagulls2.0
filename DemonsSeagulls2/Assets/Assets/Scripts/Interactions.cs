﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            if (GetComponent.collider<> == ("Interactable"))
            {
                Debug.Log("Touched a thing");
            }
        }
    }
}