using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "TowerBrick")
        {
            Debug.Log("Game Over");
            Time.timeScale = 0;
        }
    }
}
