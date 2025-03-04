using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private float speed = 200.0f;
    private Rigidbody2D rb2d;
    private bool started = false;

    private PlayerControl paddle;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        paddle = FindObjectOfType<PlayerControl>();
    }

    void GoBall()
    {
        float rand = Random.Range(0, 2) == 0 ? 1 : -1;
        rb2d.velocity = new Vector2(rand * speed / 2, speed);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            float relative = Mathf.Clamp(rb2d.position.x - paddle.gameObject.transform.position.x, -1, 1);
            Vector2 dir = new Vector2(relative, 1);

            rb2d.velocity = dir * speed;
        }
    }

    void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = new Vector3(paddle.transform.position.x, paddle.transform.position.y + 10.8f, paddle.transform.position.z);
    }

    public void RestartGame()
    {
        started = false;
        ResetBall();
    }

    void Update()
    {
        if (!started)
        {
            transform.position = new Vector3(paddle.transform.position.x, transform.position.y, transform.position.z);

            if (Input.GetKeyDown(KeyCode.Space)) {
                GoBall();
                started = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (started)
        {
            rb2d.velocity = rb2d.velocity.normalized * speed;
        }
    }
}