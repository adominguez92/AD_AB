using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionJugador_Enemigo : MonoBehaviour
{

    private GameObject jugador;
    public GameObject enemigo;
    public float velocidadEnemigo = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        jugador = collision.gameObject;
        //Debug.Log(jugador);
    }
    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            jugador = other.gameObject;
            //Debug.Log(enemigo);
            //enemigo.transform.LookAt(other.gameObject.transform);
            Perseguir();
            Observar();
        }
    }

    void Perseguir()
    {
        Vector3 distanciaEntreJugadores = jugador.transform.position - enemigo.transform.position;
        if (distanciaEntreJugadores.magnitude > 1)
        {
            enemigo.transform.position = Vector3.MoveTowards(enemigo.transform.position, jugador.transform.position, velocidadEnemigo * Time.deltaTime);
        }
    }
    void Observar()
    {
        Quaternion rotacionEnemigo = Quaternion.LookRotation(jugador.transform.position - enemigo.transform.position);
        enemigo.transform.rotation = Quaternion.Lerp(enemigo.transform.rotation, rotacionEnemigo, velocidadEnemigo * Time.deltaTime);
    }
}
