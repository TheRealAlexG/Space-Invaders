using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    public float delay;
    public float CadenciaFire;

    private AudioSource audioSource;

     void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        
    }


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", delay, CadenciaFire);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Fire()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        audioSource.Play();

    }
}
