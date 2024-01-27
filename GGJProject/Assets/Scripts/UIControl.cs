using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game");       
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}
