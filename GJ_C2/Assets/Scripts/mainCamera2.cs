using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCamera2 : MonoBehaviour
{

    public Transform target;
    public float minx=0f, maxx=-5f, c_speed=1f;

    // Start is called before the first frame update
    void Start()
    {
        minx = transform.position.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 wantedPosition = target.TransformPoint(0, 0, -10f);
        // wantedPosition.x = (wantedPosition.x < minx) ? minx : wantedPosition.x;

        if ( wantedPosition.x < minx && wantedPosition.x > maxx )
        {
            wantedPosition.x = minx;
        }   

       
        transform.position = Vector3.Lerp(transform.position,wantedPosition, Time.deltaTime * c_speed);

    }
}
