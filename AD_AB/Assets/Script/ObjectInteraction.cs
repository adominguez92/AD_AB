using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public GameObject objectPoint;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Object") 
        {
            Debug.Log("toco");
        }
    }
}
