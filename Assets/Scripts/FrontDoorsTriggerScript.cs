using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontDoorsTriggerScript : MonoBehaviour
{
    public Animator frontDoors;
    public AudioClip closeFrontDoorsAudioClip;
    public AudioClip lockFrontDoorsAudioClip;
    public Dialogue dialogue;

    private bool m_isDoorLocked = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CloseFrontDoors();
            SceneManagerScript.Instance.dialogueManagerScript.StartDialogue(dialogue);
            Destroy(gameObject);
        }

    }

    private void CloseFrontDoors()
    {
        if (!m_isDoorLocked)
        {
            m_isDoorLocked = true;
            frontDoors.SetBool("close_front_doors", true);
            AudioSource.PlayClipAtPoint(closeFrontDoorsAudioClip, frontDoors.transform.position, 2f);
            AudioSource.PlayClipAtPoint(lockFrontDoorsAudioClip, frontDoors.transform.position, 2f);
        }
    }
}
