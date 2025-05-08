using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private TextMeshProUGUI _gameoverText;

    public static event Action OnGameRestart;
    public static event Action OnGameOver;

    public static bool IsGameStopped { get; private set; } 

    private void OnEnable()
    {
        PlayerController.OnGameOver += OnGameOverPerformed;
        Menu.OnMenu += OnMenuActivate;
        Menu.OffMenu += OnMenuDisactivate;
    }
    private void OnDisable()
    {
        PlayerController.OnGameOver -= OnGameOverPerformed;
        Menu.OnMenu -= OnMenuActivate;
        Menu.OffMenu -= OnMenuDisactivate;
    }

    private void OnMenuDisactivate()
    {
        IsGameStopped = false;
    }
    private void OnMenuActivate()
    {
        IsGameStopped = true;
    }

    private void OnGameOverPerformed()
    {
        IsGameStopped = true;
        OnGameOver?.Invoke();

        _restartButton.gameObject.SetActive(true);
        _gameoverText.gameObject.SetActive(true);
        _exitButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        IsGameStopped = false;
        OnGameRestart?.Invoke();
    }  
}
