using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 30f;
    private float forwardInput;
    private Rigidbody _rigidbody;

    // Tener de referencia al Focal Point para mejorara la direccion del player segun la camara y su movimiento
    private GameObject focalPoint;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    private void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        _rigidbody.AddForce(focalPoint.transform.forward * speed * forwardInput);
    }
}
