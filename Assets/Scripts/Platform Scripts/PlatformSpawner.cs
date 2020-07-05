using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    public static PlatformSpawner instance;

    [SerializeField]
    private GameObject leftPlatform, rightPlatform;

    //platform limits
    private float left_X_Min = -4.4f, right_X_Min = 4.4f, left_X_Max = -2.8f, right_X_Max = 2.8f;

    //difference between any 2 platforms
    private float Y_Threshold = 2.6f;

    private float last_Y;

    private int spawnCount = 8;

    private int platformSpawned;

    [SerializeField]
    private Transform platformParent;

    //more variables to spawn bird enemy

  
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        last_Y = transform.position.y;
        SpawnPlatforms();
    }

    public void SpawnPlatforms()
    {
        Vector2 temp = transform.position;
        GameObject newPlatform = null;

        for (int i=0; i < spawnCount; i++)
        {
            temp.y = last_Y;

            //spwan the right platform
            if (platformSpawned % 2 == 0)
            {
                temp.x = UnityEngine.Random.Range(left_X_Min, left_X_Max);

                newPlatform = Instantiate(rightPlatform, temp, Quaternion.identity);

            }
            else
            {
                temp.x = UnityEngine.Random.Range(right_X_Min, right_X_Max);

                newPlatform = Instantiate(leftPlatform, temp, Quaternion.identity);
            }

            newPlatform.transform.parent = platformParent;

            //Keep new platforms above older ones
            last_Y += Y_Threshold;
            platformSpawned++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
