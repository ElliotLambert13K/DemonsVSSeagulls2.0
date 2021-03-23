using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private int speedRun = 10;
    private int speedJump = 300;
    public bool facingRight = false;
    public float moveOnX;
    public bool grounded;
    public bool interactWithObject;
    public bool interactWithObjectFlight;
    public bool interactWithObjectWeaponAuto;
    public bool interactWithObjectWeaponMelee;
    public bool weaponTwoActive = false;
    public bool weaponThreeActive = false;
    public float addGravity = 0.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
        Interact();
        WeaponSwitching();
    }
    void playerMovement()
    {

        moveOnX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            Jump();
        }
        if (Input.GetButtonDown("Jump") && grounded == false)
        {
            Glide();
        }
        if (moveOnX < 0.0f && facingRight == false)
        {
            FlipPlayer();
        }
        else if (moveOnX > 0.0f && facingRight == true)
        {
            FlipPlayer();
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveOnX * speedRun, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }
    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            grounded = true;
        }
        if (col.gameObject.tag == "Interactable")
        {
            interactWithObject = true;
        }
        else
        {
            interactWithObject = false;
        }
        if (col.gameObject.tag == "InteractableFlight")
        {
            interactWithObjectFlight = true;
            grounded = true;
        }
        else
        {
            interactWithObjectFlight = false;
        }
        if (col.gameObject.tag == "InteractableWeaponAuto")
        {
            interactWithObjectWeaponAuto = true;
            grounded = true;
        }
        else
        {
            interactWithObjectWeaponAuto = false;
        }
        if (col.gameObject.tag == "InteractableWeaponMelee")
        {
            interactWithObjectWeaponMelee = true;
            grounded = true;
        }
        else
        {
            interactWithObjectWeaponMelee = false;
        }
    }
    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * speedJump);
        Debug.Log("bruh");
        if (interactWithObjectFlight == true)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }
    void WeaponSwitching()
    {
        if (Input.GetButtonDown("Switch1"))
        {
            Debug.Log("Switched to Manual");
            GetComponent<ShootingRifle>().enabled = true;
            GetComponent<ShootingAuto>().enabled = false;
            GetComponent<ShootingMelee>().enabled = false;
        }
        if (Input.GetButtonDown("Switch2") && weaponTwoActive == true)
        {
            Debug.Log("Switched to Auto");
            GetComponent<ShootingRifle>().enabled = false;
            GetComponent<ShootingAuto>().enabled = true;
            GetComponent<ShootingMelee>().enabled = false;
        }
        if (Input.GetButtonDown("Switch3") && weaponThreeActive == true)
        {
            Debug.Log("Switched to Melee");
            GetComponent<ShootingRifle>().enabled = false;
            GetComponent<ShootingAuto>().enabled = false;
            GetComponent<ShootingMelee>().enabled = true;
        }
    }
    void Interact()
    {
        if (Input.GetButtonDown("Interact") && interactWithObject == true)
        {
            Debug.Log("Interacted with object");
        }
        else if (Input.GetButtonDown("Interact") && interactWithObjectWeaponAuto == true)
        {
            Debug.Log("Interacted with object auto");
            weaponTwoActive = true;
        }
        else if (Input.GetButtonDown("Interact") && interactWithObjectWeaponMelee == true)
        {
            Debug.Log("Interacted with object melee");
            weaponThreeActive = true;
        }
    }
    void Glide()
    {
        GetComponent<Rigidbody2D>().gravityScale -= addGravity;
    }
}
