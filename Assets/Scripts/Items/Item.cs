using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ran.Item
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
    public class Item : ScriptableObject
    {
        // Using `new` is overriding the default `name` property for object
        new public string name = "New Item";
        public Sprite icon = null;
        public virtual void Use()
        {
            Debug.Log("using item: " + name);
        }

    }
}
