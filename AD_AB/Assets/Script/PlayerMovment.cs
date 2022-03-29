using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public CharacterController cc;
    public float spped = 5f;

    // Update is called once per frame
    void Update()
    {
        Vector3 movementInput = Vector3.zero;
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.z = Input.GetAxisRaw("Vertical");
        Move(movementInput);
    }

    void Move(Vector3 direction)
    {
        cc.SimpleMove(direction.normalized * spped);
    }
}
