using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerScipt : MonoBehaviour
{
    public float forwardSpeedUnitsPerSecond = 20f;

    public float rotationSpeedDegreesPerSecond = 5;

    public float VerticalInput;

    public float HorizontalInput;


    private Rigidbody playerRb;

    public float rotationAngle;

    public Quaternion JimFace;

    private Vector3 forwardDirection = new Vector3(0, 0, 1);

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        JimFace = playerRb.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //fortnite: player always faces forward.  Moves in direction of left joystick.  Jogs backwards if moved back.  Right joystick rotates character direction and camera.  Camera is always
        // behind character

        //batman arkham knight: left joystick left/right will rotate batman  and camera while moving.  I.e, pushing joystick 45 degrees up/left will make Batman walk around in a circle while
        //camera stays pointed at his back.  Moving down will make Batman walk backwards.
        //If standing still, right joystick moves camera around Batman while he stands still.
        //If moving, right joystick horizontal moves Batman direction as well as camera direction.  Vertical moves camera.
        VerticalInput = Input.GetAxis("Vertical");

        HorizontalInput = Input.GetAxis("Horizontal");

        var movementDirection = new Vector3(HorizontalInput, 0, VerticalInput);

        var movementAngle = Vector3.Angle(forwardDirection, movementDirection);

        playerRb.transform.position = playerRb.transform.position + movementDirection * forwardSpeedUnitsPerSecond * Time.deltaTime;

        Vector3 relativePos = movementDirection - playerRb.transform.position;

        // the second argument, upwards, defaults to Vector3.up
        Quaternion rotation = Quaternion.LookRotation(movementDirection, Vector3.up);
        
        playerRb.transform.rotation = rotation * JimFace;
    }
}
