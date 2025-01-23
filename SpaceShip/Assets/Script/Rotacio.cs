using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacio : MonoBehaviour
{
    public float velocitatGir;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity =
            Random.insideUnitSphere * velocitatGir;
    }
}
