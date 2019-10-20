using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroText : MonoBehaviour
{
    private GameObject obj1;
    // Start is called before the first frame update

    void Start()
    {
        obj1 = GameObject.Find("Tutorial");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(obj1);
        }
    }
}
