using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
      
        
    }
}
