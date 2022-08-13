using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControllerScript : MonoBehaviour
{
    [SerializeField] private GameObject _menuScreen;
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private GameObject _pausePanel;

    public void PlayGame()
    {
        _menuScreen.SetActive(false);
        _gameScreen.SetActive(true);
        _pausePanel.SetActive(false);
        Debug.Log("Play game pressed");
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        _pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        _pausePanel?.SetActive(false);
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f;
        _menuScreen.SetActive(true);
        _gameScreen.SetActive(false);
    }
}
