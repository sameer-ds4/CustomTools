using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float dragFactor;
    public Camera mainCam;

    public FixedJoystick joypad;
    [SerializeField]
    private Rigidbody rb;

    private float hor_Movement;
    private float ver_Movemnt;

    private float yRot;
    private float xRot;


    private void FixedUpdate()
    {
        hor_Movement = Input.GetAxis("Horizontal");
        ver_Movemnt = Input.GetAxis("Vertical");

        //hor_Movement = joypad.Horizontal;
        //ver_Movemnt = joypad.Vertical;

        yRot = Input.GetAxis("Mouse X");
        xRot = Input.GetAxis("Mouse Y");


        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        mainCam.transform.eulerAngles += new Vector3(xRot, 0, 0);
        Mathf.Clamp(mainCam.transform.eulerAngles.x, -20, 20);
        
        transform.eulerAngles += new Vector3(0, yRot, 0) * 2;

        Vector3 moveDirection = transform.forward * ver_Movemnt + transform.right * hor_Movement;

        rb.AddForce(moveDirection * moveSpeed, ForceMode.Force);
        rb.drag = dragFactor;
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
