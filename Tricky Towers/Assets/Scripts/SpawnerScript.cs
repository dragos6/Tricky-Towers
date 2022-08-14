using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnerScript : MonoBehaviour
{
    public int petrifySpell = 0;
    public int zapSpell = 0;
    public bool grantPetrifySpell = false;
    public bool grantZapSpell = false;
    [SerializeField] private int numberOfMoves = 46;
    [SerializeField] int nextPieceIndex = 1;
    [SerializeField] public int nextRound = 0;
    [SerializeField] Vector3 originPos = new Vector3(-4000, 0, 0);
    [SerializeField] Vector3 labelPos = new Vector3(0, 0, 0);
    [SerializeField] private TMP_Text petrifyText;
    [SerializeField] private TMP_Text zapText;
    [SerializeField] private TMP_Text scoreboard;
    [SerializeField] private TMP_Text movesLeft;
    [SerializeField] public int score;
    //[SerializeField] TMP_Text panel;
    [SerializeField] public List<GameObject> listOfRandomPieces;
    [SerializeField] GameObject[] NextPiece;
    [SerializeField] private GameObject[] tetrisObjects;
    [SerializeField] private List<GameObject> tetrisObjects1;
    int move = 0;

    private void Start()
    {
       
    }
    private void OnEnable()
    {

        listOfRandomPieces = GetRandomElements(tetrisObjects1, numberOfMoves);
        movesLeft.text = listOfRandomPieces.Count.ToString();
        SpawnNextPiece();
    }

    private void Update()
    {
        if (score % 5 == 0 && score != 0)
        {
            grantZapSpell = true;
        }
     
        if (score % 10 == 0 && score != 0)
        {
            grantPetrifySpell = true;
        }
        Debug.Log($"nextmove:{nextPieceIndex} ; move:{move}");
        scoreboard.text = score.ToString();
        petrifyText.text = petrifySpell.ToString();
        zapText.text = zapSpell.ToString();
        
    }

    public void RestartGame()
    {
        listOfRandomPieces = GetRandomElements(tetrisObjects1, numberOfMoves);
        score = 0;
        move = 0;
        petrifySpell = 0;
        zapSpell = 0;
        movesLeft.text = listOfRandomPieces.Count.ToString();
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
        if (move < listOfRandomPieces.Count)

        {
            foreach (var item in NextPiece)
            {
                item.SetActive(false);
                if (item.name == listOfRandomPieces[nextPieceIndex].name)
                {
                    item.SetActive(true);
                }
            }
            Instantiate(listOfRandomPieces[move], transform.position, Quaternion.identity);
            move++;
            nextPieceIndex = move + 1;
            movesLeft.text = (listOfRandomPieces.Count - move).ToString();
          
        }
        else Debug.Log("Finished");


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
