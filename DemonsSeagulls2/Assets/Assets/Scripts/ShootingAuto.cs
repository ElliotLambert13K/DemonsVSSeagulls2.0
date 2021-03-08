using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAuto : MonoBehaviour
{

    public float fireRate = 10;
    public float Damage = 10;
    public LayerMask whatToHit;
    private float timeToFire = 0;
    private Transform firePoint;
    public AudioClip bulletSound;


    public Transform BulletTrailPrefab;

    //public int enemyhealthGoblin = 50;

    // Start is called before the first frame update
    void Awake()
    {
        firePoint = GameObject.Find("FirePoint").transform;
        if (firePoint == null)
        {
            Debug.LogError("No Fire Point");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else if (Input.GetButton("Fire1") && Time.time > timeToFire)
        {
            timeToFire = Time.time + 1 / fireRate;
            Shoot();
            var audio = GetComponent<AudioSource>();
            audio.PlayOneShot(bulletSound);
        }
        else
        {
            if (Input.GetButton("Fire2") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / (fireRate * 2);

                Shoot();
                var audio = GetComponent<AudioSource>();
                audio.PlayOneShot(bulletSound);
            }
        }
    }
    void Shoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, whatToHit);

        Transform bullet = Instantiate(BulletTrailPrefab, firePoint.position, firePoint.rotation);
        Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition) * 100, Color.cyan);
        if (hit.collider != null)
        {
            Debug.DrawLine(firePointPosition, hit.point, Color.red);
            Debug.Log("We hit " + hit.collider.name + " and did " + Damage + " damage");
            //if (hit.collider.tag == ("enemy"))
            //{
                //enemyhealthGoblin = enemyhealthGoblin - 10;
                // if (enemyhealthGoblin < 1)
                //{
                // Destroy(hit.collider.gameObject);
                //enemyhealthGoblin = enemyhealthGoblin + 50;
                //Debug.Log("Enemy Killed");
                //}
                //hit.collider.gameObject.GetComponent<EnemyMove>().enemyhp1 -= 10;
                //if (hit.collider.gameObject.GetComponent<EnemyMove>().enemyhp1 < 1)
                //{
                    //Destroy(hit.collider.gameObject);
                //}
            //}
            //else if (hit.collider.tag == ("boss"))
            //{
                //hit.collider.gameObject.GetComponent<BossScript>().Bossenemyhp1 -= 10;
                //if (hit.collider.gameObject.GetComponent<BossScript>().Bossenemyhp1 < 1)
                //{
                    //Destroy(hit.collider.gameObject);
                //}
            //}
        }
    }
}
