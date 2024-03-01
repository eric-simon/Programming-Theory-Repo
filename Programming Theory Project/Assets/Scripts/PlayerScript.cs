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

        var movementDirection = new Vector3(HorizontalInput, 0, VerticalInput);

        var movementAngle = Vector3.Angle(forwardDirection, movementDirection);

        playerRb.transform.position = playerRb.transform.position + movementDirection * forwardSpeedUnitsPerSecond * Time.deltaTime;

        Vector3 relativePos = movementDirection - playerRb.transform.position;

        // the second argument, upwards, defaults to Vector3.up
        Quaternion rotation = Quaternion.LookRotation(movementDirection, Vector3.up);
        
        playerRb.transform.rotation = rotation * JimFace;
    }
}
