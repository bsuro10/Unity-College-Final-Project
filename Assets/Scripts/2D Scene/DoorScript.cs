using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] Transform previousRoom;
    [SerializeField] Transform nextRoom;
    [SerializeField] private CameraControllerScript cameraController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.transform.position.x < transform.position.x)
                cameraController.MoveToNewRoom(nextRoom);
            else
                cameraController.MoveToNewRoom(previousRoom);
        }
    }
}
