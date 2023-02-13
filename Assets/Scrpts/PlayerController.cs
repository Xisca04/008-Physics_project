using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20f;
    private float forwardInput;
    private Rigidbody _rigidbody;
    private GameObject focalPoint;// Tener de referencia al Focal Point para mejorara la direccion del player segun la camara y su movimiento
    private bool hasPowerup, hasUltraPowerup;
    private float powerupForce = 15f;
    private float originalScale = 1.5f;
    private float powerupScale = 2f; // Escala aumentada por el Ultrapowerup

    public GameObject[] powerupIndicators;   // Cuenta atras del powerup

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    private void Start()
    {
        focalPoint = GameObject.Find("Focal Point");
    }

    private void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        _rigidbody.AddForce(focalPoint.transform.forward * speed * forwardInput);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountDown());
        }

        if (other.gameObject.CompareTag("UltraPowerup"))
        {
            hasUltraPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountDown());
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (other.gameObject.transform.position - transform.position).normalized;
            enemyRigidbody.AddForce(awayFromPlayer * powerupForce, ForceMode.Impulse);
        }
    }

    private IEnumerator PowerupCountDown()
    {

        if (hasUltraPowerup)
        {
            transform.localScale = powerupScale * Vector3.one;
        }

        for(int i = 0; i < powerupIndicators.Length; i++)
        {
            powerupIndicators[i].SetActive(true);
            yield return new WaitForSeconds(2);
            powerupIndicators[i].SetActive(false);
        }

        if (hasUltraPowerup)
        {
            transform.localScale = originalScale * Vector3.one;
        }
        
        hasPowerup = false;
        hasUltraPowerup = false;
    }
}
