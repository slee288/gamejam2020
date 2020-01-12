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

    public static Vector2 bulletDirection;

    // Gathering information about what happened in this collision
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Tank")
        {
            bulletRB = this.GetComponent<Rigidbody2D>();
            bulletDirection = bulletRB.velocity;
        }

        Destroy(this.gameObject);
        this.gameObject.SetActive(false);

    }

}
