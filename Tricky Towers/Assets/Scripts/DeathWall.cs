using UnityEngine;

public class DeathWall : MonoBehaviour
{
    #region MonoBehaviour
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "TowerBrick")
        {
            Destroy(collision.gameObject);
            FindObjectOfType<SpawnerScript>().score--;
        }
    }
    #endregion
}