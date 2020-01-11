using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryKill : MonoBehaviour
{
    public bool collapsable = false;
    public float rateOfCollapse = 2f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Tank")
        {
            Debug.Log(collision.gameObject.name + " has fallen");
        }
    }
}
