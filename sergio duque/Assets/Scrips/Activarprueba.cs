using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activarprueba : MonoBehaviour {

    public GameObject prueba;

    private void Start() {

        prueba.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            prueba.SetActive(true);
        }


    }
    private void OnTriggerExit(Collider other) {

        if (other.transform.tag == "Player")
        { 
            prueba.SetActive(false);
        }
    }
}