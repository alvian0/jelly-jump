using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Effect;
    public float jump = 2;
    public GameManager manager;
    public AudioSource sfx;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(0, jump);
            sfx.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pipe")
        {
            death();
        }

        if (collision.gameObject.tag == "Offset")
        {
            death();
        }
    }

    void death()
    {
        Instantiate(Effect, transform.localPosition, Quaternion.identity);
        manager.GameOver = true;
        Destroy(gameObject);
    }
}
