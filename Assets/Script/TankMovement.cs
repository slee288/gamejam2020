using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public int playerNumber = 1;
    public float rotateSpeed = 180f;
    public float speed = 12f;

    private string movementAxis;
    private string turnAxis;
    private Rigidbody tankRigidBody;
    private float movementInputValue;
    private float turnInputValue;

    private void Awake()
    {
        tankRigidBody = this.GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        tankRigidBody.isKinematic = false;
        movementInputValue = 0f;
        turnInputValue = 0f;
    }

    private void OnDisable()
    {
        tankRigidBody.isKinematic = true;
    }

    private void Start()
    {
        movementAxis = "Vertical" + playerNumber;
        turnAxis = "Horizontal" + playerNumber;
    }

    private void Update()
    {
        movementInputValue = Input.GetAxis(movementAxis);
        turnInputValue = Input.GetAxis(turnAxis);

    }

    private void FixedUpdate()
    {
        TankMove();
        TankTurn();
    }

    private void TankMove()
    {
        Vector3 movement = transform.forward * movementInputValue * speed * Time.deltaTime;
        tankRigidBody.MovePosition(tankRigidBody.position + movement);
    }

    private void TankTurn()
    {
        float turn = turnInputValue * rotateSpeed * Time.deltaTime;

        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        tankRigidBody.MoveRotation(tankRigidBody.rotation * turnRotation);
    }
}

