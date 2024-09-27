using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraV2 : MonoBehaviour
{
    float xRot;
    float yRot;
    float xRotCurrent;
    float yRotCurrent;
    public Camera player;
    public GameObject playerGameobject;
    public float sensivity = 5f;
    public float smoothTime = 0.1f;
    float currentVelocityX;
    float currentVelocityY;



    // Update is called once per frame
    void Update()
    {
        MouseMove();
    }

    void MouseMove()
    {
        //xRot += Input.GetAxis("Mouse X") * sensivity;
        xRot += Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
        //yRot += Input.GetAxis("Mouse Y") * sensivity;
        yRot += Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;
        yRot = Mathf.Clamp(yRot, -90, 90);

        xRotCurrent = Mathf.SmoothDamp(xRotCurrent, xRot, ref currentVelocityX, smoothTime);
        yRotCurrent = Mathf.SmoothDamp(yRotCurrent, yRot, ref currentVelocityY, smoothTime);

        player.transform.rotation = Quaternion.Euler(-yRotCurrent, xRotCurrent, 0f);
        playerGameobject.transform.rotation = Quaternion.Euler(0f, xRotCurrent, 0f);
    }


}
