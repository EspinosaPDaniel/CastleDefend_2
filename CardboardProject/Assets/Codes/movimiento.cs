using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float mouseSensitivity = 100.0f;

    private float xRotation = 0.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Mover el jugador si se presiona el botón derecho del ratón
        if (Input.GetMouseButton(1))
        {
            float x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
            float z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
            transform.Translate(x, 0, z);
        

        // Rotar la cámara
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.parent.Rotate(Vector3.up * mouseX);
        }
    }
}