using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    [SerializeField]
    private Selectable SelectableToSelect;

    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(SelectableToSelect.gameObject);
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
