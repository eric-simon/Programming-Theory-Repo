using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerScipt : MonoBehaviour
{
    [SerializeField]
    private float forwardSpeedUnitsPerSecond = 20f;

    private float VerticalInput;

    private float HorizontalInput;

    private Rigidbody playerRb;

    private float rotationAngle;

    private Quaternion JimFace;

    private Vector3 forwardDirection = new Vector3(0, 0, 1);

    private float tolerance = 0.01f;

    [SerializeField]
    private float myDistance = 20;

    [SerializeField]
    private float angularSpeedMradPerSecond = 785f;

    private float cameraAngle = 0;

    [SerializeField]
    private GameObject mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        JimFace = playerRb.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        VerticalInput = Input.GetAxis("Vertical");

        HorizontalInput = Input.GetAxis("Horizontal");

        var CameraInput = Input.GetAxis("Right Stick Y");

        //camera position
        var angularTravel = angularSpeedMradPerSecond * Time.deltaTime / 1000;

        if (CameraInput > 0.01)
        {
            cameraAngle += angularTravel;
        }
        else if (CameraInput < -0.01)
        {
            cameraAngle -= angularTravel;
        }

        var cameraVector = new Vector3(Mathf.Sin(cameraAngle), 0, -Mathf.Cos(cameraAngle)) * myDistance;

        mainCamera.transform.position = new Vector3(playerRb.transform.position.x + cameraVector.x, mainCamera.transform.position.y, playerRb.transform.position.z + cameraVector.z);

        //player position
        if (Mathf.Abs(VerticalInput) < tolerance)
        {
            VerticalInput = 0;
        }

        if (Mathf.Abs(HorizontalInput) < tolerance)
        {
            HorizontalInput = 0;
        }

        forwardDirection = -1 * Vector3.Normalize(cameraVector);

        var joystickDirection = new Vector3(HorizontalInput, 0, VerticalInput);

        if (joystickDirection != new Vector3(0, 0, 0))
        {
            Quaternion joystickRotation = new Quaternion();

            joystickRotation.SetFromToRotation(new Vector3(0, 0, 1), joystickDirection);

            var movementDirection = joystickRotation * forwardDirection;

            playerRb.transform.position = playerRb.transform.position + movementDirection * forwardSpeedUnitsPerSecond * Time.deltaTime;

            Vector3 relativePos = movementDirection - playerRb.transform.position;

            // the second argument, upwards, defaults to Vector3.up
            Quaternion rotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            playerRb.transform.rotation = rotation * JimFace;
        }

        //make sure camera always faces the player object
        mainCamera.transform.LookAt(playerRb.transform, Vector3.up);
    }
}
    
