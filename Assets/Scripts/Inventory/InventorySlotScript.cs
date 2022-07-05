using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ran.Item;

public class InventorySlotScript : MonoBehaviour
{
    public Image icon;

    private Item m_item;

    public void AddItem(Item item)
    {
        m_item = item;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        m_item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

}
