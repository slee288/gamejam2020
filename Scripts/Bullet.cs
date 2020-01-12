using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    Vector2 bulletDir;

    [Range(0f, 2f)]
    public float maxRecoil = 1.0f;

    private Rigidbody2D bulletRB;
    //private Rigidbody2D tankRB;

    //private bool collided = false;
    //private float timer = 0f;

    public static Vector2 bulletDirection;

    // Gathering information about what happened in this collision
    void OnCollisionEnter2D(Collision2D other)
    {
        //bulletRB = this.gameObject.GetComponent<Rigidbody2D>();
        //tankRB = other.rigidbody;

        //tankRB.velocity = Vector2.ClampMagnitude(-bulletRB.velocity, maxRecoil);
        //collided = true;
        bulletRB = this.GetComponent<Rigidbody2D>();
        bulletDirection = bulletRB.velocity;
        Destroy(this.gameObject);
        this.gameObject.SetActive(false);
    }

    /*
    void Update()
    {
        TankRecoil();
    }

    void TankRecoil()
    {
        if(collided == true)
        {
            Debug.Log(timer);
            if (timer <= 2f)
            {
                timer += Time.deltaTime;
                tankRB.AddForce(tankRB.velocity * 10f);
            }
            else
            {
                collided = false;
                timer = 0f;
            }
        }
    }
    */
}
