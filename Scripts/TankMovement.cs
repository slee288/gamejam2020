using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    [Range(1, 2)]
    public int playerNumber = 1;

    [Range(2f, 4f)]
    public float rotateSpeed = 2.5f;
    [Range(1f, 4f)]
    public float speed = 2f;

    private string movementAxis;
    private string turnAxis;
    private Rigidbody2D tankRigidBody;
    private float movementInputValue;
    private float turnInputValue;

    private void Awake() {
        tankRigidBody = this.GetComponent<Rigidbody2D>();
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
    }

    // Update is called once per frame
    void Update()
    {
        movementInputValue = Input.GetAxisRaw(movementAxis);    // vertical
        turnInputValue = Input.GetAxisRaw(turnAxis);       // horizontal
    }

    private void FixedUpdate() {
        TankMove();
        TankTurn();
    }

    private void TankMove() {
        tankRigidBody.velocity = transform.up * speed * Mathf.Clamp01(movementInputValue);
    }

    private void TankTurn()
    {
        float turn = -turnInputValue * rotateSpeed;
        this.transform.Rotate(Vector3.forward * turn);
    }
}
