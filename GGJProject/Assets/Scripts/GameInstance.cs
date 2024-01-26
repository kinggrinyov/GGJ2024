using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInstance : MonoBehaviour
{
    public static GameInstance Instance { get; private set; } = null;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayerDied()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
