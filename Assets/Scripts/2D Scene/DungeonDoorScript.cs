using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonDoorScript : MonoBehaviour
{

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        animator.SetBool("isOpen", true);
    }

}
