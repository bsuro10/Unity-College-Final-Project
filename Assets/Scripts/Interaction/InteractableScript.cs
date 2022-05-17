using UnityEngine;

public abstract class InteractableScript : MonoBehaviour
{
    public bool isInteractable { get; set; } = true;
    public abstract void Interact();

}
