using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody _rigidbody;
    private GameObject player;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;  // Calcula el vector para dirigirse hacia el player, restando las posiciones
        _rigidbody.AddForce(direction * speed);
        
        if(transform.position.y < -2)
        {
            Destroy(gameObject);
        }
    }
}
