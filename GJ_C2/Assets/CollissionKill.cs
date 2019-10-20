using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollissionKill : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private GameObject deathPoint;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
     //   if (collision.gameObject.name == "DeathTile")
     //   {
     //      Destroy(collision.gameObject);
     //   }
        if (collision.gameObject.name == deathPoint.name)
        {
            player.transform.position = respawnPoint.transform.position;
            

        }
    }



    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
