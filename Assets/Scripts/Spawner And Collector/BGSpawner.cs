using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSpawner : MonoBehaviour
{
    private GameObject[] bgs;
    private float height;
    private float highest_Y_pos;

    private void Awake()
    {
        //Get array of BGs
        bgs = GameObject.FindGameObjectsWithTag("BG");
    }
    // Start is called before the first frame update
    void Start()
    {
        height = bgs[0].GetComponent<BoxCollider2D>().bounds.size.y;

        highest_Y_pos = bgs[0].transform.position.y;

        //since the array can be in any undefined order
        for(int i=1; i< bgs.Length; i++)
        {
            if(bgs[i].transform.position.y > highest_Y_pos)
            {
                highest_Y_pos = bgs[i].transform.position.y;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "BG")
        {
            // if we collided with the highest BG
            if(target.transform.position.y >= highest_Y_pos)
            {
                
                Vector3 temp = target.transform.position;
                //if the background is not active recycle it to a higher position
                for (int i=0; i<bgs.Length; i++)
                {
                    if (!bgs[i].activeInHierarchy)
                    {
                        temp.y += height;
                        bgs[i].transform.position = temp;
                        bgs[i].gameObject.SetActive(true);
                        highest_Y_pos = temp.y;
                    }
                }
            }
        }
    }
}
