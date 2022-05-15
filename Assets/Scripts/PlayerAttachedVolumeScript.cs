using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttachedVolumeScript : MonoBehaviour
{

    public GameObject attachedVolume;

    private void Start()
    {
        DisableVolume();
    }

    public void EnableVolume()
    {
        attachedVolume.SetActive(true);
    }

    public void DisableVolume()
    {
        attachedVolume.SetActive(false);
    }
}
