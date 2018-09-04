using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]


public class Player : MonoBehaviour
{

    public float speed = 3.0F;
    public float rotateSpeed = 3.0F;
    CharacterController controller;




    // Use this for initialization
    private void Start()
    {

        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {

        Movimiento();

    }
    public void Movimiento()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * curSpeed);
    }
}