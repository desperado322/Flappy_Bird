using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _menuButton;

    public static event Action OnMenu;
    public static event Action OffMenu;

    public void MenuActivate()
    {
        OnMenu?.Invoke();
        _continueButton.gameObject.SetActive(true);
        _exitButton.gameObject.SetActive(true);
    }

    public void ContinueGame()
    {
        OffMenu?.Invoke();
        _continueButton.gameObject.SetActive(false);
        _exitButton.gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}