using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 3f;

    public Image CursorImage;
    public Sprite[] cursors;

    Transform player;
    Transform hands;

    bool isExamine;
    float camH, camV;
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>().transform;
        hands = GameObject.FindWithTag("playerHand").transform;

        //set starup Rotate
        camH = transform.eulerAngles.x;
        camV = player.eulerAngles.x;
    }
    void Update()
    {
        isExamine = GameObject.FindObjectOfType<Interact>().GetExamineState();
        CursorSetup();
    }

    void FixedUpdate()
    {
        if(!GameObject.FindObjectOfType<GameManager>().stopGame)
            Rotate();
    }

    void Rotate()
    {
        camH += Input.GetAxisRaw("Mouse Y") * -mouseSensitivity;
        camV += Input.GetAxisRaw("Mouse X") * mouseSensitivity;
        camH = Mathf.Clamp(camH, -85, 75);

        transform.rotation = Quaternion.Euler(camH,player.eulerAngles.y,0);
        player.rotation = Quaternion.Euler(0,camV,0);
        hands.rotation = Quaternion.Euler(Mathf.Clamp(camH, -90, 25), camV, 0);
    }

    void CursorSetup()
    {
        if (GameObject.FindObjectOfType<GameManager>().stopGame)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        

        if (isExamine)
            CursorImage.sprite = cursors[1];
        else
            CursorImage.sprite = cursors[0];
    }
}
