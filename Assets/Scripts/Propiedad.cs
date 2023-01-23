using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propiedad : MonoBehaviour
{
    public float min, max, total;
    public bool generarAleatorio;

    private void Start()
    {
        if(generarAleatorio) 
            total = Random.Range(min, max);
    }   
}
