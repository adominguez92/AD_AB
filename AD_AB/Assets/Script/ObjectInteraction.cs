using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public GameObject objectPoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Object")
        {
            Debug.Log("toco");
        }
    }
}
