using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs_Vehiculo : MonoBehaviour
{
    public float AccelerationOnInput = 0.1f;
    public float DecelerationRatio = 0.1f;
    public float MaxSpeed = 20f;
    public float Speed = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Variables
        float zMovement = 0;
        float xRotation = 0;

        /*
        // Usar para evitar inputs cuando el coche no toquue el suelo
        if (transform.rotation.eulerAngles.y < 10)
        {
        */
            // Controles
            if (Input.GetKey("w"))
            {
                zMovement += 1;
            }

            if (Input.GetKey("s"))
            {
                zMovement -= 1;
            }

            if (Input.GetKey("a"))
            {
                xRotation += 1;
            }

            if (Input.GetKey("d"))
            {
                xRotation -= 1;
            }
        /*
        }
        */

        // Velocidad
        Speed += AccelerationOnInput * zMovement - (Speed * DecelerationRatio);
        if (Speed < -MaxSpeed)
        {
            Speed = -MaxSpeed;
        }
        else if (Speed > MaxSpeed)
        {
            Speed = MaxSpeed;
        }
        if (Mathf.Abs(Speed) < 0.05f)
        {
            Speed = 0;
        }

        // Movimiento
        Vector3 movement = new Vector3(0, 0, Speed);
        movement = transform.rotation * movement;
        movement.y = 0; // Elimina cambios de altura
        movement.Normalize();
        transform.Translate(Mathf.Abs(Speed) * movement * Time.deltaTime, Space.World);

        // Rotacion
        if (Speed != 0)
        {
            transform.RotateAround(transform.position, new Vector3(0, 1, 0), Mathf.Abs(Speed) * xRotation * Time.deltaTime);
        }

    }
}
