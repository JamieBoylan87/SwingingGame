using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Play1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Play2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void Play3()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}