using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucles_2 : MonoBehaviour
{
    // Funciona creando un material nuevo con "Rendering Mode" tranparent

    // De completa opacidad a transparente - cambio color al objeto - bucle

    private MeshRenderer _meshRenderer;
    public Vector3[] positions;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();  // acceso al mesh renderer
    }

    private void Start()
    {
        StartCoroutine(FadeOut());
        StartCoroutine(FadeIn());
        
        StartCoroutine(MoveSphere());
    }

    private Color RandomColor()  // Cambio de color aleatoriamente 
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        
        return new Color(r, g, b);
    }

    private Vector3 RandomScale()  // Cambio de forma aleatoriamente 
    {
        float x = Random.Range(0.5f, 10f);
        float y = Random.Range(0.5f, 10f);
       
        return new Vector3 (x, y, 1);
    }

    private IEnumerator FadeOut()  // hacerse transparente
    {
        Color color = _meshRenderer.material.color;
        for (float i = 1; i >= 0; i -= 0.1f)
        {
            transform.localScale = RandomScale(); // Cambio forma a cada iteración
            color = RandomColor();  // Cambio color a cada iteración
            color = new Color(color.r, color.g, color.b, i);
            _meshRenderer.material.color = color;
            yield return new WaitForSeconds(0.5f);
        }

        // Se asegura llegar al 0 y sea transparente completamente
        color = new Color(color.r, color.g, color.b, 0);
        _meshRenderer.material.color = color;

        StartCoroutine(FadeIn());  // Cuando es transparente pasa a la función de volverse opaco
    }

    private IEnumerator FadeIn()  // hacerse opaco
    {
        Color color = _meshRenderer.material.color;
        for (float i = 1; i <= 1; i += 0.1f)
        {
            transform.localScale = RandomScale(); // Cambio forma a cada iteración
            color = RandomColor();  // Cambio color a cada iteración
            color = new Color(color.r, color.g, color.b, i);
            _meshRenderer.material.color = color;
            yield return new WaitForSeconds(0.5f);
        }

        // Se asegura llegar al 0 y sea opaco completamente
        color = new Color(color.r, color.g, color.b, 0);
        _meshRenderer.material.color = color;

        StartCoroutine(FadeOut());  // Cuando es opaco pasa a la función de volverse transparente
    }

    private IEnumerator MoveSphere()  // Recorrido de las posiciones del array
    {
        foreach (Vector3 pos in positions)
        {
            transform.position = pos;
            yield return new WaitForSeconds(1f);
        }
    }
}
