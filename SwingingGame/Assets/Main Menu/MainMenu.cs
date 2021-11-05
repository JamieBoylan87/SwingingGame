using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NextLevel ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Previous()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ToTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Start()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }
}
