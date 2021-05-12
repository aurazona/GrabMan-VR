using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // horizontal rotation speed
    public float horizontalSpeed = 1f;
    // vertical rotation speed
    public float verticalSpeed = 1f;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;
    public static Camera cam;
    public Camera TopDownCam;
    public static bool MovementSuppressed; //used to stop player movement when in top-down view
    public Light Light1;
    public Light Light2;

    void Start()
    {
        cam = Camera.main; //assigns the main camera to the cam variable
        TopDownCam.enabled = false;
        MovementSuppressed = false;
        Light1.enabled = false;
        Light2.enabled = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * horizontalSpeed; //gets the mouse's position and multiplies it by the in-game sensitivity
        float mouseY = Input.GetAxis("Mouse Y") * verticalSpeed;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90); //stops the player from going upside down

        cam.transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f);
        CamSwitch();
    }

    void CamSwitch()
    {
        if (Input.GetKeyDown(KeyCode.F))//&& (cam.enabled == true))
        {
            if (cam.enabled == true)
            {
                TopDownCam.enabled = true;
                cam.enabled = false;
                MovementSuppressed = true;
                Light1.enabled = true;
                Light2.enabled = true;
                Debug.Log("Cam is now top-down.");
            }
            else if (cam.enabled == false)
            {
                cam.enabled = true;
                TopDownCam.enabled = false;
                MovementSuppressed = false;
                Light1.enabled = false;
                Light2.enabled = false;
                Debug.Log("Cam is now first-person.");
            }
        }

    }
}
