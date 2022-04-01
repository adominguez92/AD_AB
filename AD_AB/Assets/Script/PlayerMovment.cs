using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    //variables de control publicas
    public CharacterController cc;   
    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundDistance = 0.4f;

    //variables de movimiento publicas
    public float spped = 12f;
    public float gravity = -9.81f;

    //variables privadas
    Vector3 velocity;
    bool isGrounded;


    void Update()
    {
        isGrounded = IsGrounded();

        Move();

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }

        Gravity();

    }

    void Move() 
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

        cc.Move(move * spped * Time.deltaTime);
    }

    void Gravity() 
    {
        velocity.y += gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);
    }

    bool IsGrounded() 
    {
        return Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }
}


