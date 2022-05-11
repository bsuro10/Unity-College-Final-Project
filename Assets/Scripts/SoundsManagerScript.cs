using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManagerScript : MonoBehaviour
{
    public void PlaySound(AudioClip audioClip)
    {
        AudioSource.PlayClipAtPoint(audioClip, SceneManagerScript.Instance.playerScript.transform.position);
    }

}
