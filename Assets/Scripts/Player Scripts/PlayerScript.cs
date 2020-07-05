using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D myBody;

    public float moveSpeed = 3.0f;

    public float normalPush = 10.0f;
    public float extraPush = 14.0f;


    private bool initialPush;
    private int pushCount;
    private bool playerDied;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if(playerDied)
        {
            return;
        }
        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);

        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);

        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (playerDied)
        {
            return;
        }

        if (target.tag == "ExtraPush")
        {
            if (!initialPush)
            {
                initialPush = true;
                myBody.velocity = new Vector2(myBody.velocity.x, 18.0f);

                target.gameObject.SetActive(false);

                SoundManager.instance.JumpSoundFX();

                //Exit from the onTrigger Event

                return;
            }
        }

        if(target.tag == "NormalPush")
        {
            myBody.velocity = new Vector2(myBody.velocity.x, normalPush);

            //de activate the banana
            target.gameObject.SetActive(false);
            pushCount++;

            SoundManager.instance.JumpSoundFX();
        }
        if (target.tag == "ExtraPush")
        {
            myBody.velocity = new Vector2(myBody.velocity.x,extraPush);

            //de activate the banana
            target.gameObject.SetActive(false);
            pushCount++;

            SoundManager.instance.JumpSoundFX();
        }

        //Spawn new platforms above
        if(pushCount == 2)
        {
            pushCount = 0;
            PlatformSpawner.instance.SpawnPlatforms();
        }

        if(target.tag == "FallDown" || target.tag == "Bird")
        {
            playerDied = true;
            SoundManager.instance.GameOverSoundFX();
            GameManager.instance.RestartGame();
            
        }
    }
}
