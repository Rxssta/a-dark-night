using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Juego : MonoBehaviour
{
    public Transform objetivosObj;
    public bool usarObjetivos;
    public int objetivos, totalObjectivos; 
    public TMP_Text texto;

    private void Start()
    {
        if(usarObjetivos)
        {
            totalObjectivos = objetivosObj.childCount;
        }
    }

    private void Update()
    {
        texto.text = "Objetivos: " + objetivos.ToString("0") + "/" + totalObjectivos.ToString("0");
    }
}
