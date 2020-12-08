using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 3f;

    Transform player;

    float camH, camV;
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>().transform;

        //set starup Rotate
        camH = transform.eulerAngles.x;
        camV = player.eulerAngles.x;
    }
    void Update()
    {
        CursorSetup();
    }

    void FixedUpdate()
    {
        Rotate();
    }

    void Rotate()
    {
        camH += Input.GetAxisRaw("Mouse Y") * -mouseSensitivity;
        camV += Input.GetAxisRaw("Mouse X") * mouseSensitivity;
        camH = Mathf.Clamp(camH, -85, 75);

        transform.rotation = Quaternion.Euler(camH,player.eulerAngles.y,0);
        player.rotation = Quaternion.Euler(0,camV,0);
    }

    void CursorSetup()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }
}
