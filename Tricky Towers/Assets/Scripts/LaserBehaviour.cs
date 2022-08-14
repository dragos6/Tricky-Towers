using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    private float timeToMove = 3;
    private Vector3 origPos, targetPos;
    bool moveLaser = false;
    private void Update()
    {
        /*        Debug.Log(FindObjectOfType<SpawnerScript>().nextRound);
                if (FindObjectOfType<SpawnerScript>().nextRound % 10 == 0)
                {
                    transform.position = Vector3.Lerp(transform.position, Vector3.up, 0);
                }*/
        transform.position = Vector3.Lerp(transform.position, Vector3.up, timeToMove);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "TowerBrick")
        {
            Debug.Log("Game Over");
            //Time.timeScale = 0;
            FindObjectOfType<TetrisObject>().RestartGame();

        }
    }
}
