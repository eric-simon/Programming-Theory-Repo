using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowBall : MonoBehaviour
{
    public GameObject player;
    public Vector3 myPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + myPos.x, transform.position.y, player.transform.position.z + myPos.z);
    }
}