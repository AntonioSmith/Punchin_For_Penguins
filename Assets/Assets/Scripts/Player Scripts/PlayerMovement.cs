using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterAnimation playerAnim;
    private Rigidbody myBody;
    public float walkSpeed = 5f;
    public float zSpeed = 1.5f;
    private float rotationY = -90f;
    private float rotationSpeed = 15f;
    public Vector3 jump;
    public float jumpForce = 3.0f;

    public bool isGrounded;

    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        playerAnim = GetComponentInChildren<CharacterAnimation>();
        jump = new Vector3(0.0f, 8.75f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (myBody.velocity.y <= 0.00001f)
        {
            isGrounded = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            myBody.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        RotatePlayer();
        AnimatePlayerWalk();
    }
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            myBody.AddForce(new Vector2(0, 500));
        }
        DetectMovement();
    }
    void DetectMovement()
    {
        //movement
        myBody.velocity = new Vector3(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) * (-walkSpeed), myBody.velocity.y, Input.GetAxisRaw(Axis.VERTICAL_AXIS) * (-zSpeed));
    }
    void RotatePlayer()
    {
        //rotation
        if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) > 0)
        {
            transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
        }
        else if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) < 0)
        {
            transform.rotation = Quaternion.Euler(0f, Mathf.Abs(rotationY), 0f);
        }
    }
    void AnimatePlayerWalk()
    {
        //animate player walk
        if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) != 0 || Input.GetAxisRaw(Axis.VERTICAL_AXIS) != 0)
        {
            playerAnim.Walk(true);
        }
        else
        {
            playerAnim.Walk(false);
        }
    }
}
