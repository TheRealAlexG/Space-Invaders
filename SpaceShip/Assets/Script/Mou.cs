using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mou : MonoBehaviour
{
    public float velocitat;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * velocitat;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
