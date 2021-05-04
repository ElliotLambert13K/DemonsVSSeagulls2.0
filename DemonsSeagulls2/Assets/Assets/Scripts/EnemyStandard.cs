using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyStandard : MonoBehaviour
{
    public int EnemySpeed;
    public int XMoveDirection;
    public int hp = 10;
    public GameObject Health;
    public bool facingRight = true;
    public int enemyhp1 = 50;

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
        if (hit.distance < 0.7f)
        {
            Flip();
            FlipEnemy();
            if (hit.collider.tag == "Player")
            {
                hit.collider.gameObject.GetComponent<PlayerHealth>().playerhp -= 1;
                hp = hp - 1;
                Health.gameObject.GetComponent<Text>().text = ("Health : " + hp);
                if (hit.collider.gameObject.GetComponent<PlayerHealth>().playerhp < 1)
                {
                    SceneManager.LoadScene("GameOverScene");
                }
                //hp = hp - 1;
                //Health.gameObject.GetComponent<Text>().text = ("Health : " + hp);
                //Destroy(hit.collider.gameObject);
                //SceneManager.LoadScene("GameOverScene");
            }
        }
    }
    void Flip()
    {
        if (XMoveDirection > 0)
        {
            XMoveDirection = -1;
        }
        else
        {
            XMoveDirection = 1;
        }
    }

    void FlipEnemy()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
