using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Gathering information about what happened in this collision
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);   
    }
}
