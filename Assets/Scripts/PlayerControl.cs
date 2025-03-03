using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public KeyCode moveRight = KeyCode.D;   // Move a raquete para direita
    public KeyCode moveLeft = KeyCode.A;    // Move a raquete para esquerda
    public float speed = 150;               // Define a velocidade da raquete
    public float boundX = 5.0f;             // Define os limites em X
    private Rigidbody2D rb2d;               // Define o corpo rígido 2D que representa a raquete
    private float halfWidth;                // Metade da largura da raquete

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); 
        halfWidth = GetComponent<SpriteRenderer>().bounds.extents.x; // Obtém metade da largura da raquete
    }

    void Update()
    {
        var vel = rb2d.velocity; // Acessa a velocidade da raquete

        if (Input.GetKey(moveRight)) {  // Movimenta para a direita
            vel.x = speed;
        }
        else if (Input.GetKey(moveLeft)) {  // Movimenta para a esquerda
            vel.x = -speed;                    
        }
        else {
            vel.x = 0; // Para a raquete se nenhuma tecla for pressionada
        }

        rb2d.velocity = vel; // Atualiza a velocidade da raquete

        var pos = transform.position; // Acessa a posição da raquete

        // Corrige os limites considerando a largura da raquete
        if (pos.x > boundX - halfWidth) {                  
            pos.x = boundX - halfWidth; // Corrige a posição caso ultrapasse o limite direito
        }
        else if (pos.x < -boundX + halfWidth) {
            pos.x = -boundX + halfWidth; // Corrige a posição caso ultrapasse o limite esquerdo
        }

        transform.position = pos; // Atualiza a posição da raquete
    }
}
