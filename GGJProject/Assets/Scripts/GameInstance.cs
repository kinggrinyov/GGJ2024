using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameInstance : MonoBehaviour
{
    public static GameInstance Instance { get; private set; } = null;

    public string LastPlayerNameLost { get; private set; }  = string.Empty;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void PlayerDied(string deadPlayerName)
    {
        LastPlayerNameLost = deadPlayerName;

        Invoke(nameof(GoToMainMenu), 0.50f);
    }

    private void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
