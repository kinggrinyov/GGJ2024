using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _loserText = null;

    private void Start()
    {
        if(string.IsNullOrEmpty(GameInstance.Instance.LastPlayerNameLost))
        {
            _loserText.text = "";
        }
        else
        {
            _loserText.text = $"{GameInstance.Instance.LastPlayerNameLost} Has Lost, They Garb!";
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");       
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}
