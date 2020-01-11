using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Range(1, 2)]
    public int playerNumber = 1;

    public Transform firePoint;
    public GameObject bulletPrefab;

    private string firePlayer;

    [Range(5f, 30f)]
    public float bulletForce = 20f;

    void Start()
    {
        firePlayer = "Fire" + playerNumber;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown(firePlayer))
        {
            Shoot();
        }
    }

    // Shooting action
    void Shoot()
    {
        // Create a bullet
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Bullet flies at a high velocity
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}


