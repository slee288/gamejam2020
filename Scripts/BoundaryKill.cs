using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryKill : MonoBehaviour
{
    public bool collapsable = false;
    public float rateOfCollapse = 0.025f;
    public string Code;

    public Animator top1Anim;
    public Animator top2Anim;
    public Animator bot1Anim;
    public Animator bot2Anim;

    public Tank player1;
    public Tank player2;

    private float player1Timer = 0f;
    private float player2Timer = 0f;

    //public TankInstantiate tl;

    private void setPlayers()
    {
        Tank[] players = GameObject.FindObjectsOfType<Tank>();
        foreach (Tank t in players)
        {
            if (t.name == "Player1")
            {
                player1 = t;
            }
            else
            {
                player2 = t;
            }
        }
    }

    private void Start()
    {
        setPlayers();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(player1);
        if (collapsable)
        {
            if (Code == "EAST") this.transform.position = new Vector3(transform.position.x - rateOfCollapse, transform.position.y, transform.position.z);
            else if(Code == "WEST") this.transform.position = new Vector3(transform.position.x + rateOfCollapse, transform.position.y, transform.position.z);
        }

        if(player1.getHasFell())
        {
            
            // Disable player movement and shooting
            player1.gameObject.GetComponent<TankMovement>().enabled = false;
            player1.gameObject.GetComponent<Shooting>().enabled = false;

            /* FALLING ANIMATION */
            

            if (player1Timer < 2.0f)
            {
                Debug.Log(player1Timer);
                player1Timer += Time.deltaTime;
            }
            else
            {
                if(!player1.isDead())
                {
                    player1.transform.position = new Vector3(Random.Range(-11f, -3f), Random.Range(-5f, 5f), 0);
                    player1.setAsFall(false);

                    // Enable player movement and shooting
                    player1.gameObject.GetComponent<TankMovement>().enabled = true;
                    player1.gameObject.GetComponent<Shooting>().enabled = true;
                }
                player1Timer = 0f;
            }  
        }
        else if(player2.getHasFell())
        {
            // Disable player movement and shooting
            player2.gameObject.GetComponent<TankMovement>().enabled = false;
            player2.gameObject.GetComponent<Shooting>().enabled = false;

            /* FALLING ANIMATION */


            if (player2Timer < 2.0f)
            {
                Debug.Log(player1Timer);
                player2Timer += Time.deltaTime;
            }
            else
            {
                if(!player2.isDead())
                {
                    player2.transform.position = new Vector3(Random.Range(3f, 11f), Random.Range(-5f, 5f), 0);
                    player2.setAsFall(false);

                    // Enable player movement and shooting
                    player2.gameObject.GetComponent<TankMovement>().enabled = true;
                    player2.gameObject.GetComponent<Shooting>().enabled = true;
                }
                

                player2Timer = 0f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Tank")
        {
            winningCondition(collision.gameObject);
            Debug.Log(collision.gameObject.name + " has fallen");
        }

        if (collision.gameObject.name == "Player1")
        {

            top1Anim.SetBool("c_Dead", true);
            bot1Anim.SetBool("Dead", true);

        }
        else if (collision.gameObject.name == "Player2")
        {
            top2Anim.SetBool("c_Dead", true);
            bot2Anim.SetBool("Dead", true);

        }
    }

    private void winningCondition(GameObject player)
    {

        if (player1.gameObject == player)
        {
            player1.decreaseLife();
            player1.setAsFall(true);
            if (player1.isDead())
            {
                // Disable player movement and shooting
                player1.gameObject.GetComponent<TankMovement>().enabled = false;
                player1.gameObject.GetComponent<Shooting>().enabled = false;
                Debug.Log("Player 2 Wins");
            }
        }
        else
        {
            player2.decreaseLife();
            player2.setAsFall(true);
            if (player2.isDead())
            {
                // Disable player movement and shooting
                player2.gameObject.GetComponent<TankMovement>().enabled = false;
                player2.gameObject.GetComponent<Shooting>().enabled = false;
                Debug.Log("Player 1 Wins");
            }
        }
    }
}
