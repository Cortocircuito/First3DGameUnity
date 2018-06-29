using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pill : MonoBehaviour {

    public static int pillCount;
    public GameObject[] pills;

	// Use this for initialization
	void Start () {
        Debug.Log("Pastilla " + gameObject.name);
	}
	
	// Update is called once per frame
	void Update () {

    }

    private void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Player"))
        {
            pillCount++;
            Debug.Log("Pastillas ingeridas " + pillCount);

            Timer.AddTime();

            pills = GameObject.FindGameObjectsWithTag("Pastilla");
            int numberOfPills = pills.Length - 1;

            if (numberOfPills == 0)
            {
                Debug.Log("Juego ha terminado");
                GameObject gameManager = GameObject.Find("GameManager");

                Destroy(gameManager);

                GameObject fireworks = GameObject.FindGameObjectWithTag("Fireworks");
                fireworks.GetComponent<ParticleSystem>().Play();
            }

            Destroy(gameObject);
        }
    }
}
