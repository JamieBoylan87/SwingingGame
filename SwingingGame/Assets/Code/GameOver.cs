using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static void gameOver()
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
