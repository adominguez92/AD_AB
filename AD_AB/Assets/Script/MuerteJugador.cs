using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteJugador : MonoBehaviour
{
    public GameObject jugador;
    public Transform respawnPoint;
    private float contador = 0;
    public float tiempoMuerte = 3;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            contador += Time.deltaTime;
            if (contador >= tiempoMuerte)
            {
                jugador.transform.position = respawnPoint.position;
            }
            //Debug.Log(enemigo);
            //enemigo.transform.LookAt(other.gameObject.transform);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            contador = 0;
        }
    }
}
