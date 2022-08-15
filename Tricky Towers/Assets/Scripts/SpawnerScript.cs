using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnerScript : MonoBehaviour
{
    #region Private Variables
    [SerializeField] GameObject[] _NextPieceList;                       // Stores All Tetromino Full Sprites From GameScene panel named "NextPieceList" in Hierarchy ; Count:7
    [SerializeField] private List<GameObject> _tetrisObjects;           // Stores All Tetromino Prefabs ; Count:7

    private int _move = 0;
    [SerializeField] private int _numberOfMoves = 25;
    [SerializeField] int _nextPieceIndex = 1;


    [SerializeField] private TMP_Text _petrifyCounter;                  // Needs reference from scene
    [SerializeField] private TMP_Text _zapCounter;                      // Needs reference from scene
    [SerializeField] private TMP_Text _scoreCounter;                    // Needs reference from scene
    [SerializeField] private TMP_Text _movesLeft;                       // Needs reference from scene
    #endregion

    #region Public Variables
    [SerializeField] public List<GameObject> listOfRandomPieces;        // Will contain a randomised list of every Tetromino during a game  
    public int score;
    public int nextRound = 0;
    public int petrifySpell = 0;
    public int zapSpell = 0;

    public bool grantPetrifySpell = false;
    public bool grantZapSpell = false;
    public bool gameStarting = true;
    #endregion

    #region MonoBehaviour
    private void OnEnable()                                             // TODO bugfix spawn random piece at the start of the game while using OnEnable
    {
        RestartGame();
        SpawnNextPiece();
        ClearNextPieces();
        
    }

    private void Update()
    {
        if (score % 5 == 0 && score != 0)
        {
            grantZapSpell = true;
        }

        if (score % 3 == 0 && score != 0)
        {
            grantPetrifySpell = true;
        }

        _scoreCounter.text = score.ToString();
        _petrifyCounter.text = petrifySpell.ToString();
        _zapCounter.text = zapSpell.ToString();
    }
    #endregion

    #region Public Methods
    public void RestartGame()
    {
        listOfRandomPieces = GetRandomElements(_tetrisObjects, _numberOfMoves);
        score = 0;
        _move = 0;
        petrifySpell = 0;
        zapSpell = 0;
        _nextPieceIndex = 1;
       // ShowNextPiece();
        _movesLeft.text = listOfRandomPieces.Count.ToString();
    }
    public void SpawnNextPiece()
    {
        if (grantPetrifySpell)
        {
            petrifySpell++;
            grantPetrifySpell = false;
        }
        if (grantZapSpell)
        {
            zapSpell++;
            grantZapSpell = false;
        }

        if (_move < listOfRandomPieces.Count)
        {

            if (_nextPieceIndex != _numberOfMoves)
            {
                ShowNextPiece();
            }

            Instantiate(listOfRandomPieces[_move], transform.position, Quaternion.identity);
            _move++;
            _nextPieceIndex = _move + 1;
            _movesLeft.text = (listOfRandomPieces.Count - _move).ToString();

        }
        else
        {
            FindObjectOfType<TetrisObject>().RestartGame();
            Debug.Log("Finished"); // TODO save highscore
        }
    }

    private void ClearNextPieces()
    {
        foreach (var piece in _NextPieceList)
        {
            piece.SetActive(false);
        }

    }
    private void ShowNextPiece()
    {
        foreach (var item in _NextPieceList)
        {
            item.SetActive(false);
            if (item.name == listOfRandomPieces[_nextPieceIndex].name)
            {
                item.SetActive(true);
            }
        }
    }
    #endregion

    #region Private Methods
    List<T> GetRandomElements<T>(List<T> inputList, int count)
    {
        List<T> outputList = new List<T>();
        for (int i = 0; i < count; i++)
        {
            int index = Random.Range(0, inputList.Count);
            outputList.Add(inputList[index]);
        }
        return outputList;
    }
    #endregion

}
