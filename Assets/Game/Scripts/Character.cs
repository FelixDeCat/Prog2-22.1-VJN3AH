using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour
{

    public Animator myAnimator;
    Rigidbody myRig;

    GroundSensor groundSensor;
    [SerializeField] Transform parent_Components;

    [SerializeField] WeaponBase offensiveComponent;

    Transform rotator;

    [Range(0,5000)]
    [SerializeField] float speed = 200;

    [SerializeField] float jumpForce = 5;


    public Vector3 Position
    {
        get
        {
            return this.transform.position;
        }
    }

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

        myAnimator.SetFloat("vertical", Input.GetAxis("Vertical"));
        myAnimator.SetFloat("horizontal", Input.GetAxis("Horizontal"));


        if (Input.GetButtonDown("Fire1"))
        {
            myAnimator.SetBool("IsShooting", true);
            
        }
    }

    public void ANIMEVENT_Shoot()
    {
        myAnimator.SetBool("IsShooting", false);
        offensiveComponent.ExecuteAttack();
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
