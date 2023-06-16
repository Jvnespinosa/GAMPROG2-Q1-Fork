using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{
    [SerializeField] private Image defaultIcon;
    [SerializeField] private Image itemIcon;
    public EquipmentSlotType type;
    public InventoryManager InventoryManager;

    private string DataItem;
    private ItemData itemData;

    private void Awake()
    {
        itemIcon.enabled = false;
       
    }

    public void SetItem(ItemData data)
    {
        Debug.Log($"Equiping {data.icon} to {itemIcon.sprite}");
        itemIcon.sprite = data.icon;
        DataItem = data.id;
        itemIcon.enabled = true;
        // Set the item data the and icons here
        // Make sure to apply the attributes once an item is equipped
    }

    public void Unequip()
    {
        int checker = InventoryManager.GetEmptyInventorySlot();
        if (checker != -1)
        {
            Debug.Log($"Unequip {DataItem}");
            itemIcon.sprite = null;
            itemIcon.enabled = false;

            for (int stat = 0; stat < InventoryManager.itemDatabase.Count - 1; stat++)
            {
                for (int i = 0; i < InventoryManager.itemDatabase.Count - 1; i++)
                {
                    if (DataItem == InventoryManager.itemDatabase[i].id && InventoryManager.player.attributes[stat].type ==
                        InventoryManager.itemDatabase[i].attributes[0].type)
                    {
                        InventoryManager.player.attributes[stat].value -= InventoryManager.itemDatabase[i].attributes[0].value;
                    }
                }
            }

            InventoryManager.AddItem(DataItem);
        }
        else Debug.Log($"No more SPace");

        // Check if there is an available inventory slot before removing the item.
        // Make sure to return the equipment to the inventory when there is an available slot.
        // Reset the item data and icons here
    }

    public bool WithItem()
    {
        return itemIcon.sprite != null;
    }
}
