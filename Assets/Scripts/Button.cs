using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void LoadScenes(string cena)  
    {
        SceneManager.LoadScene(cena); // Método correto
    }
}
