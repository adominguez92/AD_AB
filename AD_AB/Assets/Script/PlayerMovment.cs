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
    public float speed = 12f;
    public float currentSpeed;
    public float gravity = -9.81f;

    //variables de timer
    public float coolDownRun = 3f;
    float currentCoolDownRun;

    public float coolDownRunRecobery = 5f;
    float currentColDownRunRecobery;



    //variables privadas
    Vector3 velocity;
    bool isGrounded;
    
    void Start()
    {
        currentSpeed = speed;
        currentCoolDownRun = coolDownRun;
        currentColDownRunRecobery = coolDownRunRecobery;
    }


    void Update()
    {
        isGrounded = IsGrounded();
        

        Move();
        Run();

        if (isGrounded && velocity.y < 0)
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

        cc.Move(move * currentSpeed * Time.deltaTime);
    }

    void Run() 
    {
        bool runPressed = Input.GetKey(KeyCode.LeftShift);



        if (runPressed )
        {
            currentSpeed += Time.deltaTime;
            
        }
        else
        {
            currentSpeed = speed;
        }

        if (currentSpeed >= speed + 4)
        {
            currentSpeed = speed + 4;
        }
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


