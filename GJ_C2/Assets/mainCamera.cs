using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCamera : MonoBehaviour
{

    public Transform target;
    public float minx; 

    // Start is called before the first frame update
    void Start()
    {
        minx = transform.position.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 wantedPosition = target.TransformPoint(0, 0, -10f);
        wantedPosition.x = (wantedPosition.x < minx) ? minx : wantedPosition.x;
        transform.position = Vector3.Lerp(transform.position,wantedPosition, Time.deltaTime * 1f);

    }
}
