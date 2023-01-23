using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Linterna : MonoBehaviour
{
    public bool regenerarBateria;
    public TMP_Text texto;
    float bateria;
    public float bateriaMax;
    public GameObject luz;

    private void Start()
    {
        bateria = Mathf.Abs(bateriaMax);
    }

    void Update()
    {
        texto.text = "Bateria: " + bateria.ToString("0") + "%";
        if(luz.activeSelf)
            bateria -= Time.deltaTime;
        else if(!luz.activeSelf && bateria < bateriaMax && regenerarBateria)
            bateria += Time.deltaTime * 2f;
        
        if(bateria <= 0)
            luz.SetActive(false);

        if(Input.GetKeyDown(KeyCode.F) && bateria > 0 )
        { 
            luz.SetActive(!luz.activeSelf);
            GetComponent<AudioSource>().Play();
        }
    }

    public void AgregarBateria(float bateriaRegenerada)
    {
        bateria += bateriaRegenerada;
        if(bateria >= bateriaMax)
            bateria = bateriaMax;
    }
}
