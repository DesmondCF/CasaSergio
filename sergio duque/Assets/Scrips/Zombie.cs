using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {


    public CharacterController controller;
    public Vector3 posicionAzar;
    public float velocidadMovimiento;
    public float velocidadRotacion;
    public float tiempoDeambular;
    float referenciaDeambular;
    public float tiempoEstatico;
    float referenciaEstatico;
    public float rango;
    public Transform jugador;



    private void Start() {
        controller = GetComponent<CharacterController>();
        posicionAzar = new Vector3(Random.Range(-100f, 100f), 0, Random.Range (-100f, 100f));
        referenciaDeambular = tiempoDeambular;
        referenciaEstatico = tiempoEstatico;
	}
	

	private void Update () {

        float distancia = Vector3.Distance(jugador.position, transform.position);
        if (distancia < rango)
        {
            Perseguir();
        }
        else
        {
            Deambular();
        }

       
    
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color =Color.red;
        Gizmos.DrawWireSphere(transform.position, rango);
    }
    void Deambular()
        {

            if (tiempoDeambular > 0)
            {
                Quaternion rotacion = Quaternion.LookRotation(posicionAzar);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotacion, velocidadRotacion * Time.deltaTime);
                Vector3 movimiento = transform.TransformDirection(Vector3.forward);
                controller.SimpleMove(movimiento * velocidadMovimiento);
                tiempoDeambular -= Time.deltaTime;

            }
            else if (tiempoDeambular < 0 && tiempoEstatico > 0)
            {
                tiempoEstatico -= Time.deltaTime;
            }
            else
            {
                posicionAzar = new Vector3(Random.Range(-100f, 100f), 0, Random.Range(-100f, 100f));
                tiempoDeambular = referenciaDeambular;
                tiempoEstatico = referenciaEstatico;

            }
           

        }
    void Perseguir()
    {
        Vector3 direccion = (jugador.position - transform.position);
        Quaternion rotacion = Quaternion.LookRotation(direccion);
        direccion.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, rotacion, velocidadRotacion * Time.deltaTime);
        Vector3 movimiento = transform.TransformDirection(Vector3.forward);
        controller.SimpleMove(movimiento * velocidadMovimiento);
        tiempoDeambular -= Time.deltaTime;
    }
}
