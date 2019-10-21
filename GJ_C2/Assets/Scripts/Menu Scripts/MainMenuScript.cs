using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public AudioClip clip;
    private AudioSource source;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            SceneManager.LoadScene(0);
        }

        else if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            //Application.Quit();
            QuitGame();
        }

    }

    public void PlayCredits()   // CREDITS SCREEN is INDEX 2
    {
        SceneManager.LoadScene(3);
    }

    public void SoundPlay()
    {
        
    }
}
