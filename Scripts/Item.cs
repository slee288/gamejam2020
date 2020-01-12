using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private float itemVanishTime = 5f;
    private float itemVanishTimer = 0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Tank")
        {
            destroyItem();
        }
    }

    private void Update()
    {
        if(this.itemVanishTimer < itemVanishTime)
        {
            this.itemVanishTimer += Time.deltaTime;
        }
        else
        {
            destroyItem();
        }
    }

    private void destroyItem()
    {
        Destroy(this.gameObject);
        this.gameObject.SetActive(false);
    }
}
