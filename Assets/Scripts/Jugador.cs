using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using TMPro;

public class Jugador : MonoBehaviour
{
    public bool regenerarVida;
    public Linterna linternaScript;
    public Transform camara, linterna;
    public GameObject enemigo;
    public Juego juego;
    public float vidaMax, energiaMax, tiempoParaRecuperarse;
    float vida, energia;
    public CharacterController cc;
    public FirstPersonController fpc;
    public TMP_Text texto;

    private void Start()
    {
        energia = Mathf.Abs(energiaMax);
        vida = Mathf.Abs(vidaMax); 
        linternaScript = linterna.gameObject.GetComponent<Linterna>();
    }

    void Update()
    {
        texto.text = "Vida: " + vida.ToString("0") + "\n\nEnergia: " + energia.ToString("0");
        if(Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit raycast;
            if(Physics.Raycast(camara.position, camara.forward, out raycast, 3.5f))
            {
                if(raycast.collider.gameObject.CompareTag("Objetivos"))
                {
                    juego.objetivos++;
                    Destroy(raycast.collider.gameObject);
                    if(juego.objetivos == juego.totalObjectivos)
                        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
                }
                else if(raycast.collider.gameObject.CompareTag("Bateria"))
                {
                    float total = raycast.collider.gameObject.GetComponent<Propiedad>().total;   
                    linternaScript.AgregarBateria(total);
                    Destroy(raycast.collider.gameObject);
                }
                else if(raycast.collider.gameObject.CompareTag("Vida"))
                {
                    float total = raycast.collider.gameObject.GetComponent<Propiedad>().total;   
                    Curar(total);
                    Destroy(raycast.collider.gameObject);
                }
            }
        }

        if(regenerarVida && vida < vidaMax)
            vida += Time.deltaTime;
        

        if(Input.GetKey(KeyCode.LeftShift) && cc.velocity.magnitude >= 1f && energia >= 0)
        {
            Vector3 xyz = new Vector3(30,0,0);
            linterna.localEulerAngles = Vector3.Lerp(linterna.localEulerAngles, xyz, Time.deltaTime * 2.5f);

            energia -= Time.deltaTime * 2.5f;

            if(energia <= 0)
            {    
                energia = -Mathf.Abs(tiempoParaRecuperarse);
                fpc.m_WalkSpeed = 2.5f;
                fpc.m_RunSpeed = 5f;
            }
        }
        else 
        {
            Vector3 xyz = new Vector3(0,0,0);
            linterna.localEulerAngles = Vector3.Lerp(linterna.localEulerAngles, xyz, Time.deltaTime * 2.5f);

            if(energia < Mathf.Abs(energiaMax))
            {
                energia += Time.deltaTime * 2f;
                if(energia >= 0)
                {
                    fpc.m_WalkSpeed = 5f;
                    fpc.m_RunSpeed = 10f;
                }
            }
        }
    }

    public void RecibirDaño(float daño)
    {
        vida -= daño;
        if(vida <= 0)
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    public void Curar(float vidaRegenerada)
    {
        vida += vidaRegenerada;
        if(vida >= vidaMax)
            vida = vidaMax;
    }

}
