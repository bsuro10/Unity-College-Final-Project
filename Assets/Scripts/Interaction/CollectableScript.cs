using UnityEngine;
using UnityEngine.Events;

public class CollectableScript : InteractableScript
{
    public Item item;
    public UnityEvent afterCollectAction = new UnityEvent();

    public override void Interact()
    {
        Collect();
    }

    protected virtual void Collect()
    {
        bool wasCollected = SceneManagerScript.Instance.inventoryManagerScript.Add(item);
        if (wasCollected)
        {
            afterCollectAction.Invoke();
            Destroy(gameObject);
        }
    }
}
