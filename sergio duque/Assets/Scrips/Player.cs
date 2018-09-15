using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]


public class Player : MonoBehaviour
{

    public float speed = 3.0F;
    public float rotateSpeed = 3.0F;
    CharacterController controller;

    public GameObject cam;
    public float rot_x;



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
        transform.Rotate(0, Input.GetAxis("Mouse X") * rotateSpeed, 0);
        //cam.transform.Rotate(Input.GetAxis("Mouse Y")*-1,0,0);
        rot_x += (Input.GetAxis("Mouse Y") * -1) * rotateSpeed;
        
        if (rot_x > 0 && rot_x < 60)
        {
            cam.transform.localRotation = Quaternion.Euler(rot_x, 0, 0);
        }
            
        if(rot_x < 0 && rot_x > -60)
        {
            cam.transform.localRotation = Quaternion.Euler(rot_x, 0, 0);
        }
        if(rot_x > 60)
        {
            rot_x = 60;
        }
        if ( rot_x < -60)
        {
            rot_x  = - 60;
        }


        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * curSpeed);

        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
    }
}