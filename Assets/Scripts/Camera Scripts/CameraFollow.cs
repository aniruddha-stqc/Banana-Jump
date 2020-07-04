using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;

    private bool followPlayer;

    public float min_Y_Threshold = -2.6f;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    void Follow()
    {
        //don't follow below threshold of camera
        if(target.transform.position.y < (transform.position.y - min_Y_Threshold) )
        {
            followPlayer = false;
        }

        //keep following is ON if moves over camera on top
        if(target.position.y > transform.position.y)
        {
            followPlayer = true;
        }

        //Keep following player
        if (followPlayer)
        {

        Vector3 temp = transform.position;
        temp.y = target.position.y;

        transform.position = temp;
        }
        
    }
}
