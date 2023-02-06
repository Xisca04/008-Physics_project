using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucles : MonoBehaviour
{
    public string[] names;  // Elementos del array de nombres

    // Elementos del array para INSTANCIAR POSICIONES
    public Vector3[] positions;
    public GameObject prefab;

    void Start()
    {
        // Muestra los numeros del 1 al 10
        /*for(int i = 1; i <= 10; i++)
        {
            Debug.Log(i);
        }

        // Muestra los numeros pares del 0 al 10
        for(int i = 0; i <= 10; i += 2)
        {
            Debug.Log(i);
        }
        

        // Muestra la tabla de multiplicar del 10
        for(int i = 1; i <= 10; i++)
        {
            Debug.Log($"10 x {i} = {10 * i}");
        }
        

        // Muestra todos los elementos de una ARRAY
        for(int i = 0; i < names.Length; i++)
        {
            Debug.Log(names[i]);
        }
        */
        // Instanciar posiciones
        for(int i = 0; i < positions.Length; i++)
        {
            Instantiate(prefab, positions[i], Quaternion.identity);
        }
    }

    
}
