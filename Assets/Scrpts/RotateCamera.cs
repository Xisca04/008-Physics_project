using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    // Rotacion de la camara

    public float rotationSpeed;
    private float horizontalInput;

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime * horizontalInput);
    }
}
