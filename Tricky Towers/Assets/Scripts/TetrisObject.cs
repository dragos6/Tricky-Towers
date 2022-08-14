using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TetrisObject : MonoBehaviour
{
    bool isCollided = false;
    bool isDeathwall = false;
    bool isHardFalling = false;
    SpawnerScript spawner;
    public GameObject[] gameObjects;
    public GameObject[] towerBricks;
    [SerializeField] private Sprite stoneBrick;
    public Transform[] listOfChildrenObjects;
    Rigidbody2D rb;

    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        // FindObjectOfType<TMP_Text>().text = score.ToString();
        if (isCollided)
        {
            FindObjectOfType<SpawnerScript>().score++;
            gameObject.tag = "TowerBrick";
            listOfChildrenObjects = gameObject.GetComponentsInChildren<Transform>();
            foreach (var obj in listOfChildrenObjects)
             {
                 obj.tag = "TowerBrick";
            }
            isCollided = false;
            FindObjectOfType<SpawnerScript>().SpawnNextPiece();
            enabled = false;
        }
        if (isDeathwall)
        {
            FindObjectOfType<SpawnerScript>().score--;

            FindObjectOfType<SpawnerScript>().SpawnNextPiece();

            Destroy(this.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-0.5f, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(0.5f, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.Q) && !isHardFalling)
        {
            transform.Rotate(new Vector3(0, 0, -90));
        }
        else if (Input.GetKeyDown(KeyCode.E) && !isHardFalling)
        {
            transform.Rotate(new Vector3(0, 0, 90));
        }
        else if (Input.GetKeyDown(KeyCode.S) && !isHardFalling)
        {
            rb.gravityScale = rb.gravityScale * 8;
            isHardFalling = true;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            Destroy(gameObject);
            gameObjects = GameObject.FindGameObjectsWithTag("TowerBrick");
            foreach (var obj in gameObjects)
            {
                Destroy(obj);
            }

            FindObjectOfType<SpawnerScript>().RestartGame();
            FindObjectOfType<SpawnerScript>().SpawnNextPiece();
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            towerBricks = GameObject.FindGameObjectsWithTag("TowerBrick");
            foreach (var obj in towerBricks)
            {
                obj.GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                SpriteRenderer[] sprites = obj.GetComponentsInChildren<SpriteRenderer>();
                foreach (SpriteRenderer sprite in sprites)
                {
                    sprite.sprite = stoneBrick;
                }

            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.gameObject.tag != "Deathwall")
        {
            isCollided = true;
            isHardFalling = false;
        }
        else if (collision.gameObject.tag == "Deathwall")
        {
            isDeathwall = true;
        }
    }

}
