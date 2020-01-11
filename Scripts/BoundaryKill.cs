using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryKill : MonoBehaviour
{
    public bool collapsable = false;
    public float rateOfCollapse = 0.025f;
    public string Code;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (collapsable)
        {
            if (Code == "EAST") this.transform.position = new Vector3(transform.position.x - rateOfCollapse, transform.position.y, transform.position.z);
            else if(Code == "WEST") this.transform.position = new Vector3(transform.position.x + rateOfCollapse, transform.position.y, transform.position.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Tank")
        {
            Debug.Log(collision.gameObject.name + " has fallen");
        }
    }
}
