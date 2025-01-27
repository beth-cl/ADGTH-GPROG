using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class playermovement : MonoBehaviour
{
    //public variables
    public float moveSpeed = 5f;
    public float turnSpeed = 700f;

    //private variables
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerMove();
    }

    void playerMove()
    {
        //uses movement commands from the build settings and assigns them to variables
        float MoveX = Input.GetAxis("Horizontal");
        float MoveZ = Input.GetAxis("Vertical");
        float MoveY = Input.GetAxis("Jump");

        Vector3 moveDirection = new Vector3(MoveX, MoveY, MoveZ).normalized;

        if (moveDirection.magnitude >= 0.1f) //if the player is moving
        {
            //sets the target angle of the player model so it matches the movement
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
            float Angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSpeed, 0.1f);
            transform.rotation = Quaternion.Euler(90f, Angle, 0f);

            //moves the player
            Vector3 moveVelocity = moveDirection * moveSpeed * Time.deltaTime; //amount moved per movement at speed calculations
            rb.MovePosition(rb.position + moveVelocity); //changes position based amount moved added to the current coords
        }

    }
}
