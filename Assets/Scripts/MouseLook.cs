using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float MouseSensitivity = 300f;

    public Transform PlayerBody;

    float xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    private void Update()
    {
        //x ekseninde yapt���m�z de�i�ikli�i bodyde yap�yoruz 
        //y ekseninde ya�t���m�z� ise camerada yap�yoruz

        float MouseX = Input.GetAxis("Mouse X")*MouseSensitivity*Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y")*MouseSensitivity*Time.deltaTime;

        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        PlayerBody.Rotate(Vector3.up * MouseX);
    }

}
