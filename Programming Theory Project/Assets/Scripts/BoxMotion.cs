using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMover : MonoBehaviour
{
    public BoxMotion Motion = new NoMotionBox();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Motion.Move(transform.position);
    }
}
