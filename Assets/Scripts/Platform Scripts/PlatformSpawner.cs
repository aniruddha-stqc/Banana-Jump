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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
