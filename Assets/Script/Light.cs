using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag=="Player")
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
