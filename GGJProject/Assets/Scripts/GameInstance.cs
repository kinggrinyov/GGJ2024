using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameInstance : MonoBehaviour
{
    public static GameInstance Instance { get; private set; } = null;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void PlayerDied(string gameobjectName)
    {
        SceneManager.LoadScene("MainMenu");
        
        //SEND THIS
        string result = gameobjectName + "Wins!";

    }
}
