using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    Vector2 hitPoint;

    [Range(1f, 3f)]
    public float maxRecoilForce = 1f;

    private Rigidbody2D bulletRB;
    private Rigidbody2D tankRB;

    // Gathering information about what happened in this collision
    void OnTriggerEnter2D(Collider2D other)
    {
        hitPoint = this.transform.position;
        Destroy(this.gameObject);
        TankRecoil(other);
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        bulletRB = this.GetComponent<Rigidbody2D>();
    }

    void TankRecoil(Collider2D tank)
    {
        tankRB = tank.attachedRigidbody;
        Debug.Log(tankRB);

    }
}
