using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ran.Item;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/CrystalItem")]
public class CrystalItem : Item
{
    public string areaTagName;
    public GameObject crystalPrefab;
    public AudioClip successUsingItemAudio;

    public override void Use()
    {
        base.Use();
        Collider[] hits = Physics.OverlapSphere(SceneManagerScript.Instance.playerScript.transform.position, 2f);
        if (hits.Length > 0)
        {
            foreach (Collider hit in hits)
            {
                if (hit.CompareTag(areaTagName))
                {
                    Transform playerTransform = SceneManagerScript.Instance.playerScript.transform;
                    Instantiate(crystalPrefab, playerTransform.position + playerTransform.TransformDirection(new Vector3(0, -0.5f, 1f)), playerTransform.rotation);
                    SceneManagerScript.Instance.inventoryManagerScript.Remove(this);
                    if (successUsingItemAudio)
                        AudioSource.PlayClipAtPoint(successUsingItemAudio, hit.transform.position);
                }
            }
        }
    }
}
