using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Money : MonoBehaviour
{
    // Start is called before the first frame update
    private int c_amount;
    [SerializeField] 
    private Text coinCounter;

    // Sound Implementation
    public AudioSource source;
    public AudioClip coinSound;
    void Start()
    {
        c_amount = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        coinCounter.text = "Coins: " + c_amount.ToString();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
  //      Debug.Log(collision.gameObject.GetComponent<Coin>());
        if (collision.gameObject.GetComponent<Coin>())
        {
            c_amount += 1;
            Destroy(collision.gameObject);
            source.PlayOneShot(coinSound);

        }
  

    }


}
