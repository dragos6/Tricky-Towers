using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TetrisObject : MonoBehaviour
{
    #region Private Variables
    private bool _isCollided = false;
    private bool _isDeathwall = false;
    private GameObject[] _gameObjects;
    private GameObject[] _towerBricks;
    [SerializeField] private Sprite _stoneBrick;
    private Transform[] _listOfChildrenObjects;
    private Rigidbody2D _rb;
    #endregion

    #region MonoBehaviour
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (_isCollided)
        {
            FindObjectOfType<SpawnerScript>().score++;
            gameObject.tag = "TowerBrick";
            _listOfChildrenObjects = gameObject.GetComponentsInChildren<Transform>();
            foreach (var obj in _listOfChildrenObjects)
            {
                obj.tag = "TowerBrick";
            }
            _isCollided = false;
            FindObjectOfType<SpawnerScript>().SpawnNextPiece();
            enabled = false;
        }

        if (_isDeathwall)
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

        else if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0, 0, 90));
        }

        else if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(new Vector3(0, 0, -90));
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }

        else if (FindObjectOfType<SpawnerScript>().petrifySpell != 0)                                               // Turns fallen bricks into immovable objects
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                _towerBricks = GameObject.FindGameObjectsWithTag("TowerBrick");
                foreach (var obj in _towerBricks)
                {
                    obj.GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                    SpriteRenderer[] sprites = obj.GetComponentsInChildren<SpriteRenderer>();
                    foreach (SpriteRenderer sprite in sprites)
                    {
                        sprite.sprite = _stoneBrick;
                    }
                }
                FindObjectOfType<SpawnerScript>().petrifySpell--;
            }
        }

        else if (FindObjectOfType<SpawnerScript>().zapSpell != 0)                                                   // Delets falling piece
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                FindObjectOfType<SpawnerScript>().zapSpell--;
                FindObjectOfType<SpawnerScript>().SpawnNextPiece();
                Destroy(gameObject);

            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.gameObject.tag != "Deathwall")
        {
            _isCollided = true;
        }
        else if (collision.gameObject.tag == "Deathwall")
        {
            _isDeathwall = true;
        }
    }
    #endregion

    #region Public Methods
    public void RestartGame()
    {
        Destroy(gameObject);
        _gameObjects = GameObject.FindGameObjectsWithTag("TowerBrick");
        foreach (var obj in _gameObjects)
        {
            Destroy(obj);
        }

        FindObjectOfType<SpawnerScript>().RestartGame();
        FindObjectOfType<SpawnerScript>().SpawnNextPiece();
    }
    #endregion
}