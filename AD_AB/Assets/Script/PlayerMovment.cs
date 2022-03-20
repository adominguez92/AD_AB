using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public Rigidbody rb;
    public float spped = 5f;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
       
        Vector3 move = new Vector3(horizontal, rb.velocity.y, vertical);
        rb.velocity = move.normalized * spped * Time.deltaTime;

    }
}
