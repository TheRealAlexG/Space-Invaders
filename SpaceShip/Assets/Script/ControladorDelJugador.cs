using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Limits
{
    public float xMin, xMax, zMin, zMax;
}

public class ControladorDelJugador : MonoBehaviour
{
    public float velocitat;
    public float balanceig;
    public Limits limits;
    public GameObject projectil;
    public GameObject[] armes = new GameObject[2];
    public float fireDelta = 0.5F;
    public GameObject explosioJugador;

    private Rigidbody rb;
    //private int indexArma = 0;
    private float nextFire = 0.5F;
    private float myTime = 0.0F;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movimentHorizontal = Input.GetAxis("Horizontal");
        float movimentVertical = Input.GetAxis("Vertical");

        Vector3 moviment = new Vector3(movimentHorizontal, 0f, movimentVertical);

        this.rb.velocity = moviment * this.velocitat;

        this.rb.position = new Vector3(
            Math.Clamp(this.rb.position.x, this.limits.xMin, this.limits.xMax),
            this.rb.position.y,
            Math.Clamp(this.rb.position.z, this.limits.zMin, this.limits.zMax)
            );

        this.rb.rotation = Quaternion.Euler(0f, 0f, -moviment.x * this.balanceig);
    }

    // Update is called once per frame
    private void Update()
    {
        myTime += Time.deltaTime;
        // Ctrl was pressed, launch a projectile
        if (Input.GetButton("Fire1") && myTime > nextFire)
        {
            //Instantiate(projectil, armes[indexArma].transform.position, transform.rotation);
            //indexArma = (indexArma + 1) % armes.Length;

            Instantiate(projectil, armes[0].transform.position, transform.rotation);
            Instantiate(projectil, armes[1].transform.position, transform.rotation);
            nextFire = myTime + fireDelta;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            GameObject clone = Instantiate(explosioJugador, transform.position, transform.rotation);
            Destroy(clone, 2);
        }
    }
}
