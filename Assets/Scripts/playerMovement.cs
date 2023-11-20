using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class playerMovement : MonoBehaviour
{
    public float currentSpeed;
    public float walkingSpeed;
    public float runningSpeed;
    public float jumpSpeed;
    public float gravity;

    public CharacterController characterController;

    private float baselineGravity;
    private float xMove;
    private float zMove;
    private Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = walkingSpeed;
        baselineGravity = gravity;
    }

    // Update is called once per frame
    void Update()
    {
        xMove = Input.GetAxis("Horizontal") * currentSpeed * Time.deltaTime;
        zMove = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;

        move = transform.right * xMove +
            transform.up * gravity +
            transform.forward * zMove;

        characterController.Move(move);
        if (Input.GetKey(KeyCode.Space) && characterController.isGrounded)
        {
            // jump
        }

    }
}
