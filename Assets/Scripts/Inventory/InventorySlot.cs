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
        InventoryManager.Instance.UseItem(itemData);
        int InventoryCheck = InventoryManager.Instance.GetEmptyInventorySlot();
        int EquipmentCheck = InventoryManager.Instance.GetEquipmentSlot(itemData.slotType);
        

        if (itemData.type == ItemType.Consumable)
        {
            InventoryManager.Instance.UseItem(itemData);
            itemData = null;
            itemIcon.sprite = null;
            itemIcon.enabled = false;
        }
        else
        {
            if (InventoryCheck == -1 && InventoryManager.Instance.equipmentSlots[EquipmentCheck].WithItem())
            { }
            else
            {
                InventoryManager.Instance.UseItem(itemData);
                itemData = null;
                itemIcon.sprite = null;
                itemIcon.enabled = false;
            }
        }
        // Reset the item data and the icons here
    }

    public bool HasItem()
    {
        return itemData != null;
    }
}
