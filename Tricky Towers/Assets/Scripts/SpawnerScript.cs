using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject[] tetrisObjects;
    // Start is called before the first frame update
    void Start()
    {
        //int index = Random.Range(0, tetrisObjects.Length);
        //Instantiate(tetrisObjects[index], transform.position, Quaternion.identity);
        SpawnRandom();
        //StartCoroutine(StartSpawning());
    }

    public void SpawnRandom()
    {
        int index = Random.Range(0, tetrisObjects.Length);
        Instantiate(tetrisObjects[index], transform.position, Quaternion.identity);
    }

    public void returningCall()
    {
        Debug.Log(1);
    }
 /*   IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(3f);
        int index = Random.Range(0, tetrisObjects.Length);
        Instantiate(tetrisObjects[index], transform.position, Quaternion.identity);
        StartCoroutine(StartSpawning());

    }*/
}
