using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private ItemData itemData;
    public Image itemIcon;

    public void SetItem(ItemData data)
    {
        // Set the item data the and icons here
        itemData = data;
        itemIcon.sprite = data.icon;
        itemIcon.enabled = true;
    }

    public void UseItem()
    {
        

        if (itemData.type == ItemType.Consumable)
        {
            InventoryManager.Instance.UseItem(itemData);
            itemData = null;
            itemIcon.sprite = null;
            itemIcon.enabled = false;
        }
        else if (itemData.type == ItemType.Equipabble)
        {
            InventoryManager.Instance.UseItem(itemData);
            itemData = null;
            itemIcon.sprite = null;
            itemIcon.enabled = false;
        }
        // Reset the item data and the icons here
    }

    public bool HasItem()
    {
        return itemData != null;
    }

    public bool checkKey()
    {
        if (itemData.type == ItemType.Key)
        {
            return true;
        }
        return false;
    }
}
