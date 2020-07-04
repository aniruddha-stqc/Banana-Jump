using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D myBody;

    public float moveSpeed = 2.0f;

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
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "ExtraPush")
        {
            if (!initialPush)
            {
                initialPush = true;
                myBody.velocity = new Vector2(myBody.velocity.x, 18.0f);

                target.gameObject.SetActive(false);

                //SoundManager

                //Exit from the onTrigger Event

                return;
            }
        }
    }
}
