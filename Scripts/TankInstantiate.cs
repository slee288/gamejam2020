using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankInstantiate : MonoBehaviour
{
    public Tank tankPrefab1;
    public Tank tankPrefab2;

   // public Animator bonchaeInvinc;
    //public Animator cannonInvinc;

    void Awake()
    {
        Tank Player1 = Instantiate(tankPrefab1,
                                         new Vector3(Random.Range(-11f, -9f), Random.Range(-5f, 5f), 0),
                                         Quaternion.Euler(0, 0, -90));
        Tank Player2 = Instantiate(tankPrefab2,
                                         new Vector3(Random.Range(9f, 11f), Random.Range(-5f, 5f), 0),
                                         Quaternion.Euler(0, 0, 90));

        Player1.setInvincible(true);
        Player2.setInvincible(true);

        Player1.gameObject.name = "Player 1";
        Player2.gameObject.name = "Player 2";
    }

    // Start is called before the first frame update
    void Start()
    {

        //cannonInvinc.SetBool("dead", true);
    }
}
