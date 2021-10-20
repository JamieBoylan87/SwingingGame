using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public Rigidbody2D origin;
    public Material mat;
    private LineRenderer line;

    private bool pull = false;
    private bool update = false;

    public float stayTime = 1f;
    public float lineWidth = .1f;
    public float speed = 75f;
    public float pullForce = 10f;
    private Vector3 velocity;
    private IEnumerator timer;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        if (!line)
        {
            line = gameObject.AddComponent<LineRenderer>();
        }
        line.startWidth = lineWidth;
        line.endWidth = lineWidth;
        line.material = mat;

    }

    public void setStart(Vector2 targetPos)
    {
        Vector2 dir = targetPos - origin.position;
        dir = dir.normalized;
        velocity = dir * speed;  
        transform.position = origin.position + dir;
        pull = false;
        update = true;
        if (timer != null)
        {
            StopCoroutine(timer);
            timer = null;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!update)
        {
            return;
        }

        if (pull)
        {
            Vector2 dir = (Vector2)transform.position -origin.position;
            origin.AddForce(dir * pullForce);
        }
        else
        {
            transform.position += velocity * Time.deltaTime;
            float distance = Vector2.Distance(transform.position, origin.position);
            if (distance > 50)
            {
                update = false;
                line.SetPosition(0, Vector2.zero);
                line.SetPosition(1, Vector2.zero);
                return;

            }
        }
        line.SetPosition(0, transform.position);
        line.SetPosition(1, origin.position);

    }

    IEnumerator reset (float delay)
    {
        yield return new WaitForSeconds(delay);
        update = false;
        line.SetPosition(0, Vector2.zero);
        line.SetPosition(1, Vector2.zero);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Rope")
        {
            velocity = Vector2.zero;
            pull = true;
            timer = reset(stayTime);
            StartCoroutine(timer);
        }
        else
        {
            velocity = Vector2.zero;
            timer = reset(0);
            StartCoroutine(timer);
        }
    }

}
