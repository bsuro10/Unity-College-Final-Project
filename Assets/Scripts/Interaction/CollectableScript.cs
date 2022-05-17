using UnityEngine;

public class CollectableScript : InteractableScript
{
    public Item item;

    public override void Interact()
    {
        Collect();
    }

    protected virtual void Collect()
    {
        bool wasCollected = SceneManagerScript.Instance.inventoryManagerScript.Add(item);
        if (wasCollected)
            Destroy(gameObject);
    }
}
