using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   public Transform cameraTarget;
   public Transform playerModel;
   public float minAngle;
   public float maxAngle;
   public float mouseSensitivity;
   public bool stickCamera;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float aimX = Input.GetAxis("Mouse X");
        float aimY = Input.GetAxis("Mouse Y");
        cameraTarget.rotation *= Quaternion.AngleAxis(aimX * mouseSensitivity, Vector3.up);
        cameraTarget.rotation *= Quaternion.AngleAxis(-aimY * mouseSensitivity, Vector3.right);


        var angleX = cameraTarget.localEulerAngles.x;
        if (angleX > 180 && angleX < maxAngle)
        {
            angleX = maxAngle;
        }
        else if (angleX < 180 && angleX > minAngle)
        {
            angleX = minAngle;
        }

        cameraTarget.localEulerAngles = new Vector3(angleX, cameraTarget.localEulerAngles.y, 0);

        if (stickCamera)
        {
            playerModel.rotation = Quaternion.Euler(0, cameraTarget.rotation.eulerAngles.y, 0);
        }

    }
}
