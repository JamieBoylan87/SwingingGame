using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject Key;
    public GameObject door;


    public void DestroyKey()
    {
        Destroy(Key);
    }

    public void DestroyDoor()
    {
        Destroy(door);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            DestroyKey();
            DestroyDoor();
            Debug.Log("Hi");
        }
    }
}
