using UnityEngine;

public class PlayerRespawnScript : MonoBehaviour
{
    private Transform currentCheckpoint;
    private HealthScript playerHealth;

    private void Awake()
    {
        playerHealth = GetComponent<HealthScript>();
    }

    public void Respawn()
    {
        transform.position = currentCheckpoint.position;
        playerHealth.Respawn();
        Camera.main.GetComponent<CameraControllerScript>().MoveToNewRoom(currentCheckpoint.parent);
        ResetEnemies();
    }

    private void ResetEnemies()
    {
        Transform currentRoom = currentCheckpoint.parent;
        foreach(HealthScript enemyHealthScript in currentRoom.GetComponentsInChildren<HealthScript>())
        {
            enemyHealthScript.ResetHealth();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Checkpoint"))
        {
            currentCheckpoint = collision.transform;
            collision.GetComponent<Collider2D>().enabled = false;
        }
    }
}
