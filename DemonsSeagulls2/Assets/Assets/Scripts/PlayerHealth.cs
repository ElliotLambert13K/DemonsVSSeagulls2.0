using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int playerhp = 10;

    public void Update()
    {
        if (gameObject.transform.position.y < -7)
        {
            Die();
        }
    }

    public void Die()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
