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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
    }
    void playerMovement()
    {

        moveOnX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            Jump();
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
    }
    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * speedJump);
        grounded = false;
        Debug.Log("bruh");
    }
}
