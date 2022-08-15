using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    #region Private Variables
    private float timeToMove = 0.003f;
    private Vector3 origPos, targetPos;
    bool moveLaser = false;
    #endregion

    #region Private Methods
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "TowerBrick")
        {
            FindObjectOfType<TetrisObject>().RestartGame();
        }
    }
    #endregion

}
