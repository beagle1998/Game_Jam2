using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_Time : MonoBehaviour
{
    private float time=0f;
    [SerializeField] private Transform player;
    [SerializeField] private int location;
    [SerializeField] private Text timer_counter;
    // Start is called before the first frame update

    void Start()
    {
       timer_counter.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    //    timer_counter.gameObject.SetActive(true);
        time = time + Time.deltaTime;
       // Debug.Log(time);
        timer_counter.text = "Time Wasted: " + (Mathf.RoundToInt(time)).ToString();
        if (player.transform.position.x <= location)
        {
            timer_counter.gameObject.SetActive(true);
            
        }
       

    }
}
