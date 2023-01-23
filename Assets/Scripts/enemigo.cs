using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : MonoBehaviour
{
    public Jugador jugador;
    public Transform objetivo;
    public float velocidad, distacia, daño;

    void Update()
    {
        RaycastHit raycast;
        if(Physics.Raycast(transform.position, transform.forward, out raycast, Mathf.Abs(distacia)))
        {
            if(raycast.collider.gameObject.CompareTag("Player"))
            {
                jugador.RecibirDaño(Mathf.Abs(Time.deltaTime * daño));
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, objetivo.position, Mathf.Abs(Time.deltaTime * velocidad));
                transform.LookAt(objetivo);
            }
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, objetivo.position, Mathf.Abs(Time.deltaTime * velocidad));
            transform.LookAt(objetivo);
        }
    }
}
