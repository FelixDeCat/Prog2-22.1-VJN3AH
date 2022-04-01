using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour
{
    Rigidbody myRig;

    GroundSensor groundSensor;
    [SerializeField] Transform parent_Components;

    [Range(0,5000)]
    [SerializeField] float speed = 200;

    [SerializeField] float jumpForce = 5;

    void Start()
    {
        myRig = GetComponent<Rigidbody>();
        groundSensor = parent_Components.GetComponentInChildren<GroundSensor>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(groundSensor.IsGrounded)
            {
                myRig.AddForce(transform.up * jumpForce);
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 vert = Input.GetAxis("Vertical") * transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horiz = Input.GetAxis("Horizontal") * transform.right* speed * Time.fixedDeltaTime;
        Vector3 move = horiz + vert;
        move.y = myRig.velocity.y;
        myRig.velocity = move;
    }
}
