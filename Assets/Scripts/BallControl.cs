using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speedMultiplier = 1.1f; // Aumenta a velocidade após colisão com o player
    public float maxSpeed = 25f;         // Define um limite para a velocidade da bola

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 2);
    }

    void GoBall()
    {
        float rand = Random.Range(0, 2) == 0 ? 1 : -1;
        rb2d.velocity = new Vector2(150 * rand, -15);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            // Calcula novo vetor de velocidade baseado na posição da colisão
            float hitFactor = (transform.position.x - coll.transform.position.x) / coll.collider.bounds.size.x;

            Vector2 newDir = new Vector2(hitFactor, 1).normalized; // Direção ajustada
            rb2d.velocity = newDir * Mathf.Min(rb2d.velocity.magnitude * speedMultiplier, maxSpeed); // Aumenta a velocidade, mas limita
        }

        if (coll.gameObject.tag == "Brick"){
            Destroy(coll.gameObject);  
}

    }

    void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    public void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }
}