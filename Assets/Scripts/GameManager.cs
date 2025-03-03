using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static int Score = 0;
    private static int Lifes = 3;

    public GUISkin layout;
    GameObject theBall;
    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball");
    }

    public static void UpdateScore(int score)
    {
        Score += score;
    }

    public static void DecreaseLife()
    {
        Lifes--;
    }

    public static void SetLife(int count)
    {
        Lifes = count;
    }

    public static void SetScore(int count)
    {
        Score = count;
    }

    private void Update()
    {
        Debug.Log(Lifes);
        if (Lifes <= 0)
        {
            Lifes = 3;
            Score = 0;
            SceneManager.LoadScene("GameOver");
        }
    }
    void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width - 150 - 12, 20, 100, 100), "" + Score);
    }

}
