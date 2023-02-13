using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    // Rotacion de la camara

    private float rotationSpeed = 30;
    private float horizontalInput;

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
       
        // Rotamos el Focal Point y la cámara hace el efecto de rotar
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime * horizontalInput);
    }
}
