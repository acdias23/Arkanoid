using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int HitCount;
    public int Score;
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            HitCount--;

            if (HitCount <= 0)
            {
                GameManager.UpdateScore(Score);

                Destroy(gameObject);
            }
        }
    }
}
