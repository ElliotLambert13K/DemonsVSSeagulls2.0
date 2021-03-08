using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Switch1"))
        {
            Debug.Log("Switched to Manual");
            GetComponent<ShootingRifle>().enabled = true;
            GetComponent<ShootingAuto>().enabled = false;
            GetComponent<ShootingMelee>().enabled = false;
        }
        if (Input.GetButtonDown("Switch2"))
        {
            Debug.Log("Switched to Auto");
            GetComponent<ShootingRifle>().enabled = false;
            GetComponent<ShootingAuto>().enabled = true;
            GetComponent<ShootingMelee>().enabled = false;
        }
        if (Input.GetButtonDown("Switch3"))
        {
            Debug.Log("Switched to Melee");
            GetComponent<ShootingRifle>().enabled = false;
            GetComponent<ShootingAuto>().enabled = false;
            GetComponent<ShootingMelee>().enabled = true;
        }
    }
}
