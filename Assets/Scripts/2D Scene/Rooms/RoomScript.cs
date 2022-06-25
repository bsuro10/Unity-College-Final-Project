using UnityEngine;

public class RoomScript : MonoBehaviour
{

    [SerializeField] private GameObject[] enemies;

    public void ActivateRoom(bool status)
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
            {
                enemies[i].SetActive(status);
            }    
        }
    }

}
