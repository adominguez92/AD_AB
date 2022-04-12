using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LigthOff : MonoBehaviour
{
    public GameObject ligth;
    public bool luzOn = false;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemigo")) 
        {
            ligth.SetActive(luzOn);
            luzOn = !luzOn;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemigo"))
        {
            ligth.SetActive(luzOn);
            luzOn = !luzOn;
        }

    }
}
