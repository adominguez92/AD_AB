using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aparicion_Enemigo : MonoBehaviour
{
    public float tiempoAparcicion = 1;
    public float duracuionAparicion = 1;
    private bool estado = true;
    private float contador = 0;

    void Start()
    {
        //gameObject.SetActive(false);    
    }
    // Update is called once per frame
    void Update()
    {
        contador += Time.deltaTime;
        //Debug.Log(contador);


        switch (estado)
        {
            case true:
                if (contador >= duracuionAparicion)
                {
                    var enemigo = gameObject.GetComponentInChildren<Rigidbody>(true);
                    if (enemigo != null)
                    {
                        enemigo.gameObject.SetActive(false);
                    }
                    contador = 0;
                    estado = !estado;
                }
                break;
            default:
                if (contador >= tiempoAparcicion)
                {
                    var enemigo = gameObject.GetComponentInChildren<Rigidbody>(true);
                    if (enemigo != null)
                    {
                        enemigo.gameObject.SetActive(true);
                    }
                    contador = 0;
                    estado = !estado;
                }
                break;
        }
    }
}
