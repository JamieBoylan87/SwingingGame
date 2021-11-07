using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KeyDoor : MonoBehaviour
{
    public int LevelToLoad;
    public GameObject Key;
    private Key key;
    public bool keyCheck = false;
    private GameMaster gm;
    public GameObject EndScreen;
    public Text scoreText;
    private ScoreManager sm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        sm = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreManager>();

        key = Key.GetComponent<Key>();
        EndScreen.gameObject.SetActive(false);

    }

    private void Update()
    {
       keyCheck = key.key ;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (key.open)
            {
                gm.InputText.text = ("[E] to Enter");
                if (Input.GetKey("e"))
                {
                    Time.timeScale = 0f;
                    scoreText.text = sm.score.ToString();
                    EndScreen.gameObject.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (key.open)
            {
                if (Input.GetKey("e"))
                {
                    Time.timeScale = 0f;
                    scoreText.text = sm.score.ToString();
                    EndScreen.gameObject.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (key.open)
        {
            gm.InputText.text = ("");
        }
    }
}
