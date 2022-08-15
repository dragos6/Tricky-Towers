using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTetromino : MonoBehaviour
{
    public bool tetroFall;
    public float speed = 2f;
    public float defaut_Y = -60;
    public GameObject Tetromino;
    // Start is called before the first frame update
    void Awake()
    {
        
        Instantiate(Tetromino);
        StartCoroutine(StartSpawning());
    }

    // Update is called once per frame
    void Update()
    {
        //Move();
    }

    void Move()
    {
       /* if(tetroFall)
        {
            Vector3 temp = transform.position;
            temp.z = speed * Time.deltaTime;
            transform.position = temp;
        }*/
    }

    IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(3f);
        Instantiate(Tetromino);
        Debug.Log(transform.position.x +"  "+ transform.position.y);
        //Tetromino.transform.position = new Vector2(transform.position.x, defaut_Y);
        StartCoroutine(StartSpawning());
    }
}
