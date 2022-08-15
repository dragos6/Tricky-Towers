using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
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
