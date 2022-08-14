using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWall : MonoBehaviour
{

    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "TowerBrick")
        {
            Destroy(collision.gameObject);
            FindObjectOfType<SpawnerScript>().score--;
        }
    }
}

