using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private Transform nextRoom;
    [SerializeField] private Transform previousRoom;
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
            boxCollider.isTrigger = false;
            cameraController.MoveToNewRoom(nextRoom);
            nextRoom.GetComponent<RoomScript>().ActivateRoom(true);
            previousRoom.GetComponent<RoomScript>().ActivateRoom(false);
        }
    }

}
