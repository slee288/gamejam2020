using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Range(1, 2)]
    public int playerNumber = 1;

    public Transform firePoint;
    public GameObject bulletPrefab;
    public Animator explodeAnim;

    private string firePlayer;

    [Range(0f, 160f)]
    public float bulletForce = 40f;

    private int maxAmmo = 10;
    private int currentAmmo = 10;
    [Range(0f, 1f)]
    public float dps = 0.3f;

    private float shootTimer = 0f;


    private float timer;
    [Range(0.5f, 1.5f)]
    public float reloadTime = 1.5f;

    void Start()
    {
        firePlayer = "Fire" + playerNumber;
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer += Time.deltaTime;
        if(Input.GetButtonDown(firePlayer))
        {
            Debug.Log("Shoot");
            if (currentAmmo > 0 && shootTimer >= dps)
            {
                shootTimer = 0f;
                Shoot();
            }
        }

        if(currentAmmo < maxAmmo)
        {
            Reload();
        }
    }

    // Shooting action
    void Shoot()
    {
        // Create a bullet
        currentAmmo--;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        explodeAnim.Play("Fire", 0, 0.3f);

        // Bullet flies at a high velocity
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    // Reload
    void Reload()
    {
        if(timer < reloadTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0f;
            currentAmmo++;
        }
    }
}
