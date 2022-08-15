using UnityEngine;

public class MenuControllerScript : MonoBehaviour
{
    #region Private Variables
    [SerializeField] private GameObject _menuScreen;
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject[] _sceneGameObjects;
    [SerializeField] private GameObject _sceneFallingPiece;
    #endregion

    #region Public Variables
    public bool gameIsStarting = true;
    #endregion

    #region Public Methods
    public void PlayGame()
    {
        _menuScreen.SetActive(false);
        _gameScreen.SetActive(true);
        _pausePanel.SetActive(false);
        FindObjectOfType<SpawnerScript>().RestartGame();
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
        _sceneFallingPiece = GameObject.FindGameObjectWithTag("Tetromino");
        Destroy(_sceneFallingPiece);
        _sceneGameObjects = GameObject.FindGameObjectsWithTag("TowerBrick");

        foreach (var obj in _sceneGameObjects)
        {
            Destroy(obj);
        }
        //FindObjectOfType<SpawnerScript>().gameStarting = false;
        gameIsStarting = false;
        _menuScreen.SetActive(true);
        _gameScreen.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    #endregion

}
