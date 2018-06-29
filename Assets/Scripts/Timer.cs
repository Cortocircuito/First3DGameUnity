using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public static float maxTime = 60f;

    private static float countdown = 0f;
    private GameObject[] pills;

    // Use this for initialization
    void Start()
    {
        Debug.Log("Comienza el juego");
        Pill.pillCount = 0;
        countdown = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        pills = GameObject.FindGameObjectsWithTag("Pastilla");
        string pillTotalMessage = string.Format("Pastillas pendiente ingerir {0}", pills.Length);
        Debug.Log(pillTotalMessage);

        //El deltaTime es el tiempo en segundos que ha pasado desde que se
        //renderizó en pantalla el último frame anterior.

        countdown -= Time.deltaTime; // countdown = countdown - Time.deltaTime;

        //Debug.Log("Cuenta atrás :" + countdown);
        if (countdown <= 0)
        {
            Debug.Log("Te has quedado sin tiempo... HAS PERDIDO!!!!");

            Pill.pillCount = 0;

            SceneManager.LoadScene("MainScene");
        }
        else
        {
            //Debug.Log("Tiempo " + countdown);
        }
    }

    public static void AddTime(float addTime = 10)
    {
        countdown += addTime;
        Debug.Log("Ha aumentado en " + addTime + " segundos más");
    }
}