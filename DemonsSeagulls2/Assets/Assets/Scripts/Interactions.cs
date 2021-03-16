using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    public bool interactWithObject;

    // Update is called once per frame
    void Update()
    {
        Interact();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Interactable")
        {
            interactWithObject = true;
        }
        else
        {
            interactWithObject = false;
        }
    }

    void Interact()
    {
        if (Input.GetButtonDown("Interact") && interactWithObject == true)
        {
            Debug.Log("Interacted with object");
        }
    }
}
