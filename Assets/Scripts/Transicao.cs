using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transicao : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Brick");
        print(gos.Length);
        if(gos.Length == 0){
            if (scene.name == "Fase1"){
                SceneManager.LoadScene("Fase2");
            }
            if (scene.name == "Fase2")
            {
                SceneManager.LoadScene("Win");
            }
        }
    }

}
