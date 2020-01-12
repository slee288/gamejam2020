using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TankMovement : MonoBehaviour
{
    public Tank currentTank;

    [Range(1, 2)]
    public int playerNumber = 1;

    [Range(2f, 4f)]
    public float rotateSpeed = 2.5f;
    [Range(1f, 4f)]
    public float speed = 2f;
    [Range(4f, 8f)]
    public float cannonRotateSpeed = 6.0f;
    [Range(0f, 1f)]
    public float tankRecoil = 0.5f;


    private float timer = 0f;
    private bool tankCollided = false;

    private Vector2 currentVelocity;
    private string movementAxis;
    private string turnAxis;
    private string cannonAxis;
    private Rigidbody2D tankRigidBody;
    private float movementInputValue;
    private float turnInputValue;
    private float cannonTurnValue;
    private Transform tankCannon;

    private void Awake() {
        tankRigidBody = this.GetComponent<Rigidbody2D>();
        tankCannon = transform.Find("Cannon");
    }

    private void OnEnable() {
        tankRigidBody.isKinematic = false;
        movementInputValue = 0f;
        turnInputValue = 0f;
    }

    private void OnDisable()
    {
        tankRigidBody.isKinematic = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        movementAxis = "Vertical" + playerNumber;
        turnAxis = "Horizontal" + playerNumber;
        cannonAxis = "HorizontalCannon" + playerNumber;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTank.getInvincible()) 
            Debug.Log(currentTank.getInvincible());

        movementInputValue = Input.GetAxisRaw(movementAxis);    // vertical
        turnInputValue = Input.GetAxisRaw(turnAxis);       // horizontal
        cannonTurnValue = Input.GetAxisRaw(cannonAxis);


        TankMove();
        TankTurn();
        CannonTurn();

        TankRecoil();
    }

    private void TankMove() {
        tankRigidBody.velocity = transform.up * speed * Mathf.Clamp01(movementInputValue);
        tankRigidBody.angularVelocity = 0;
    }

    private void TankTurn()
    {
        float turn = -turnInputValue * rotateSpeed;
        this.transform.Rotate(Vector3.forward * turn);
    }

    private void CannonTurn()
    {
        float turn = -cannonTurnValue * cannonRotateSpeed;
        tankCannon.Rotate(Vector3.forward * turn);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if(currentTank.getInvincible() == false)
        {
            if (other.gameObject.tag == "Bullet")
            {
                Debug.Log("Hit");
                tankCollided = true;
            }
        }

        if(other.gameObject.tag == "Shield")
        {
            currentTank.setInvincible(true);
        }

        
    }



    private void TankRecoil()
    {
        if(tankCollided == true)
        {
            if(timer <= 0.2f)
            {
                timer += Time.deltaTime;
                tankRigidBody.AddForce(Vector2.ClampMagnitude(Bullet.bulletDirection, tankRecoil) * 10f);

            }
            else
            {
                tankCollided = false;
                timer = 0f;
            }
        }
    }

}
