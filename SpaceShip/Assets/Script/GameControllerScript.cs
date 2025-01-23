using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    int puntuacio = 0;

    public GameObject limitEsquerre;
    public GameObject limitDret;
    public GameObject[] asteroides;
    public float pausaEntreAsteroides;
    public int nAsteroidesPerOnada;
    public TextMeshProUGUI txtPuntuacio;

    public Button textRestart;
    public TextMeshProUGUI textGameOver;
    public Image BlurImg;



    // Start is called before the first frame update
    void Start()
    {
        BlurImg.gameObject.SetActive(false);
        textRestart.gameObject.SetActive(false);
        textGameOver.gameObject.SetActive(false);
        
       StartCoroutine(Partida());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GeneraOnadaAsteroides()
    {
        for (int nAsteroides = 0; nAsteroides < nAsteroidesPerOnada; nAsteroides++)
        {
            GameObject asteroideNou = asteroides[Random.Range(0, asteroides.Length)];
            Vector3 posicioNova = new Vector3(
                Random.Range(
                    limitEsquerre.transform.position.x,
                    limitDret.transform.position.x
                    ),
                limitEsquerre.transform.position.y,
                limitEsquerre.transform.position.z
                );

            Instantiate(asteroideNou, posicioNova, Quaternion.identity);

            yield return new WaitForSeconds(pausaEntreAsteroides);
        }
    }

   public IEnumerator Partida()
    {
        while (true)
        {
            yield return GeneraOnadaAsteroides();
            pausaEntreAsteroides *= 0.9f;
            nAsteroidesPerOnada = (int)(nAsteroidesPerOnada * 1.2);
            
            yield return new WaitForSeconds(1);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;

        
    }

    public void Puntua(int punts)
    {
        puntuacio += punts;
        ActualitzaElMarcador();

    }



    private void ActualitzaElMarcador()
    {
        txtPuntuacio.text = puntuacio + " punts";
    }

    public void GameOver()
    {
        textRestart.gameObject.SetActive(true);
        textGameOver.gameObject.SetActive(true);
        BlurImg.gameObject.SetActive(true);
        Time.timeScale = 1;
        
    }
}
