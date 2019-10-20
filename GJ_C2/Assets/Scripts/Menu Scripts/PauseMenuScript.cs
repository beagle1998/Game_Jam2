using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public void ContinueGame()
    {
        SceneManager.LoadScene(1);
    }
    public void PauseGame()
    {
        SceneManager.LoadScene(2);//insert pause scene here
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(1);

    }
}
