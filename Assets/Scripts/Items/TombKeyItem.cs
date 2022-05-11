using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/TombKeyItem")]
public class TombKeyItem : Item
{
    public TombTags connectedTomb;
    public AudioClip successUsingKeyAudio;

    public override void Use()
    {
        base.Use();
        Collider[] hits = Physics.OverlapSphere(SceneManagerScript.Instance.playerScript.transform.position, 2f);
        if (hits.Length > 0)
        {
            foreach (Collider hit in hits)
            {
                if (hit.CompareTag(connectedTomb.ToString()))
                {
                    hit.gameObject.SetActive(false);
                    SceneManagerScript.Instance.inventoryManagerScript.Remove(this);
                    AudioSource.PlayClipAtPoint(successUsingKeyAudio, hit.transform.position);
                }
            }
        }
    }
}

public enum TombTags { GreenTomb, BlueTomb, OrangeTomb }