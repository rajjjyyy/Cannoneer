using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private Vector3 Vrotate, Hrotate, Propulsion;
    private Quaternion fVRotate, Stab, fStab, origin;
    private float rSpeed = 250f, vrotate, Propulse, move = 10f;
    private bool shouldStab = false;

    private void Start()
    {
        origin = transform.rotation;
    }
    void MoveForward() 
    {
        Propulse = Input.GetAxisRaw("Jump");
        Propulsion = transform.forward * Propulse * move * Time.deltaTime;
        transform.position += (-1 * Propulsion);
    }
    void RotateVert() 
    {
        vrotate = Input.GetAxisRaw("Vertical");
        Vrotate = new Vector3(vrotate, 0, 0);
        fVRotate = Quaternion.Euler(Vrotate * (rSpeed / 2) * Time.deltaTime);
        transform.localRotation = transform.localRotation * fVRotate;
    }
    void RotateHor() 
    {
        Hrotate = new Vector3(0, Input.GetAxis("Horizontal"), 0);
        transform.Rotate(Hrotate * rSpeed * Time.deltaTime, Space.World);
        /*hrotate = Input.GetAxisRaw("Horizontal");

        Hrotate = new Vector3(0,hrotate, 0);
        fHRotate = Quaternion.Euler(Hrotate * (rSpeed / 2) * Time.deltaTime);
        transform.localRotation = transform.localRotation * fHRotate;*/
    }
    

    void FixedUpdate()
    {
        MoveForward();
        RotateVert();
        RotateHor();
        


    }
    private void OnCollisionEnter(Collision collision)
    {
        shouldStab = true;
    }
}
