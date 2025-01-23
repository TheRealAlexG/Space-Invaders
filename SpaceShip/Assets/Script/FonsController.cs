using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FonsController : MonoBehaviour
{
    public float velocitatScroll;
    
    float llargada;
    Vector3 posicioInicial;

    // Start is called before the first frame update
    void Start()
    {
        posicioInicial = transform.position;
        llargada = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        float novaPosicio = Mathf.Repeat(Time.time * velocitatScroll, llargada);
        transform.position = posicioInicial + Vector3.back * novaPosicio;
    }
}
