using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruccioPerContacte : MonoBehaviour
{
    public GameObject explosio;
    public int puntuacio = 20;
     GameControllerScript gameControllerScript;
    private void Start()
    {
        gameControllerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (this.tag == "Enemy" && other.tag == "Enemy") return;

        if (other.tag != "Frontera")
        {
            gameControllerScript.Puntua(puntuacio);
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            GameObject clone = Instantiate(explosio, transform.position, transform.rotation);
            Destroy(clone, 2);

            if(other.tag == "Player")
            {
                Time.timeScale = 1;
                gameControllerScript.GameOver();
                Time.timeScale = 0;

            }
           
        }
        

    }
}
