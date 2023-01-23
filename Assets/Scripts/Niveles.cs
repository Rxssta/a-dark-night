using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Niveles : MonoBehaviour
{
    public void CargarNivel(int nivel)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nivel);
    }

    public void SalirDelJuego()
    {
        Application.Quit();
    }
}
