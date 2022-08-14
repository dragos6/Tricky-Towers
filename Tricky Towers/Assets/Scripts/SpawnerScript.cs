using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnerScript : MonoBehaviour
{

    [SerializeField] private GameObject[] tetrisObjects;
    [SerializeField] private List<GameObject> tetrisObjects1;
    [SerializeField] public List<GameObject> listOfRandomPieces;
    [SerializeField] private int numberOfMoves = 46;
    [SerializeField] int nextPieceIndex;
    [SerializeField] private TMP_Text scoreboard;
    [SerializeField] private TMP_Text movesLeft;
    [SerializeField] public int score;
    int move= 0;

    private void OnEnable()
    {
        listOfRandomPieces = GetRandomElements(tetrisObjects1, numberOfMoves);
        movesLeft.text = listOfRandomPieces.Count.ToString();
        //SpawnRandom();
        SpawnNextPiece();

    }

    private void Update()
    {
        scoreboard.text = score.ToString();
    }

    public void RestartGame()
    {
        listOfRandomPieces = GetRandomElements(tetrisObjects1, numberOfMoves);
        score = 0;
        move = 0;
        movesLeft.text = listOfRandomPieces.Count.ToString();
    }
    public void SpawnNextPiece()
    {
        nextPieceIndex = move + 1;
        Instantiate(listOfRandomPieces[move], transform.position, Quaternion.identity);
        move++;
        movesLeft.text = (listOfRandomPieces.Count - move).ToString();
    }
    public void SpawnRandom()
    {
        int index = Random.Range(0, tetrisObjects.Length);
        Instantiate(tetrisObjects[index], transform.position, Quaternion.identity);
    }

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
}
