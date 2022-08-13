using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisObject : MonoBehaviour
{
    float lastFall = 0f;
    bool isCollided = false;
    bool isDeathwall= false;
    float speed = 10f;
    public GameObject[] gameObjects;
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (isCollided)
        {
            FindObjectOfType<SpawnerScript>().SpawnRandom();
            enabled = false;
        }
        if(isDeathwall)
        {
            FindObjectOfType<SpawnerScript>().SpawnRandom();
            Destroy(this.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("left pressed");
            //rb.AddRelativeForce(Vector2.left * Time.deltaTime * speed);
            transform.position += new Vector3(-0.5f, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("right pressed");

            //rb.AddRelativeForce(Vector2.right * Time.deltaTime * speed);
            transform.position += new Vector3(0.5f, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(new Vector3(0, 0, -90));
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.gravityScale = rb.gravityScale * 8;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            gameObjects = GameObject.FindGameObjectsWithTag("Tetromino");
            foreach (var obj in gameObjects)
            {
                Destroy(obj);
            }
            FindObjectOfType<SpawnerScript>().SpawnRandom();
        }


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.gameObject.tag != "Deathwall")
        {
            isCollided = true;
            
            Debug.Log(collision.gameObject.tag);

        }
        else if(collision.gameObject.tag == "Deathwall")
        {
            isDeathwall = true;
        }


    }
}
