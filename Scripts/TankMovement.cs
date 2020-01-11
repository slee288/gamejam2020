using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TankMovement : MonoBehaviour
{
    [Range(1, 2)]
    public int playerNumber = 1;

    [Range(2f, 4f)]
    public float rotateSpeed = 2.5f;
    [Range(1f, 4f)]
    public float speed = 2f;
    [Range(2f, 4f)]
    public float cannonRotateSpeed = 3.0f;

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
        movementInputValue = Input.GetAxisRaw(movementAxis);    // vertical
        turnInputValue = Input.GetAxisRaw(turnAxis);       // horizontal
        cannonTurnValue = Input.GetAxisRaw(cannonAxis);
    }

    private void FixedUpdate() {
        TankMove();
        TankTurn();
        CannonTurn();
    }

    private void TankMove() {
        tankRigidBody.velocity = transform.up * speed * Mathf.Clamp01(movementInputValue);
    }

    private void TankTurn()
    {
        float turn = -turnInputValue * rotateSpeed;
        this.transform.Rotate(Vector3.forward * turn);
    }

    private void CannonTurn()
    {
        float turn = -cannonTurnValue * rotateSpeed;
        tankCannon.Rotate(Vector3.forward * turn);
    }
}
