using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooletTwo : MonoBehaviour
{
    Vector3 direction;
    float speed = 0.25f;
    private Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {
        firePoint = GameObject.Find("FirePoint").transform;
        // Debug.Log(gameObject.name + "   " + transform.position);
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        direction = mousePosition - firePointPosition;

        if (gameObject.name == "bulletUP")
        {
            direction = direction + new Vector3(1, 0);
        }
        if (gameObject.name == "bulletLOW")
        {
            direction = direction - new Vector3(1, 0);
        }
        
    }

    void Update()
    {
        transform.position = transform.position + (direction.normalized * speed);
    }


}