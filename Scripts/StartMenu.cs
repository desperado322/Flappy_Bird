using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Slider _audioSlider;
    [SerializeField] private TextMeshProUGUI _audioText;

    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void OpenSettings()
    {
        _startButton.gameObject.SetActive(false);
        _settingsButton.gameObject.SetActive(false);
        _exitButton.gameObject.SetActive(false);

        _audioSlider.gameObject.SetActive(true);
        _audioText.gameObject.SetActive(true);
        _backButton.gameObject.SetActive(true);
    }

    public void CloseSettings()
    {
        _startButton.gameObject.SetActive(true);
        _settingsButton.gameObject.SetActive(true);
        _exitButton.gameObject.SetActive(true);

        _audioSlider.gameObject.SetActive(false);
        _audioText.gameObject.SetActive(false);
        _backButton.gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}