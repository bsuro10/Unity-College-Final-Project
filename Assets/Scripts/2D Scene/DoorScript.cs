using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private Transform nextRoom;
    [SerializeField] private CameraControllerScript cameraController;

    private BoxCollider2D boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cameraController.MoveToNewRoom(nextRoom);
            boxCollider.isTrigger = false;
        }
    }
}
