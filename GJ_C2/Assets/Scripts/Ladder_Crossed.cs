using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ladder_Crossed : MonoBehaviour
{
    // Start is called before the first frame update
    private int l_amount;
    [SerializeField]
    private Text ladderCounter;
    void Start()
    {
        l_amount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        ladderCounter.text = "Ladder: " + l_amount.ToString();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //      Debug.Log(collision.gameObject.GetComponent<Coin>());
        if (collision.gameObject.GetComponent<Ladder>())
        {
            l_amount += 1;
            Destroy(collision.gameObject);

        }


    }


}
