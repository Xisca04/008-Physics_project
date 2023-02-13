using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 5f;
    private Rigidbody _rigidbody;
    private GameObject player;
    private float yMin = -5; // Altura que si cae por debajo de este se destruye

    private void Awake() // Funciona como el Start, se ejecuta una vez; si es una cosa propia conviene que este aquí, si es una cosa que estemos buscando como el enemy al player ha de estar en Start
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        // Cálculo de la dirección enemigo -> player
        Vector3 direction = (player.transform.position - transform.position).normalized;  // Calcula el vector para dirigirse hacia el player, restando las posiciones

        // Aplicacr la fuerza para que el enemigo se mueva siempre hacia el player a la misma velocidad
        _rigidbody.AddForce(direction * speed);
        

        // Comprueba si el enemy se cae de la plataforma -> se destruye
        if(transform.position.y < yMin)
        {
            Destroy(gameObject);
        }
    }
}
