using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonFX : MonoBehaviour
{
    public AudioSource mySounds;
    public AudioClip buttonHover;
    public AudioClip buttonClick;
    public void HoverSound()
    {
        mySounds.PlayOneShot(buttonHover);
    }

    // Update is called once per frame
    public void ClickSound()
    {
        mySounds.PlayOneShot(buttonClick);
    }
}
