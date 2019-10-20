using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillLadder : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ladder")
        {
            Destroy(collision.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
