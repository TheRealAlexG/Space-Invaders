using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroideController : MonoBehaviour
{
    public int puntuacio = 10;
    public int resistencia = 10;
    public GameObject explosio;
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

            if (other.tag == "Player")
            {
                gameControllerScript.GameOver();
                Time.timeScale = 0;


            }
        }

        
    }
}
