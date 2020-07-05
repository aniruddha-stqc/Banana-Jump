using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D target)
    {
        if( target.tag == "BG" ||
            target.tag == "Platform" ||
            target.tag == "Bird" ||
            target.tag == "ExtraPush" ||
            target.tag == "NormalPush")
        {
            target.gameObject.SetActive(false);
        }
    }
}
