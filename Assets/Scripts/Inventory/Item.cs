using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactable
{
    [SerializeField] private InventoryManager inventoryManager;
    public override void Interact()
    {
        int inventorySlots = inventoryManager.GetEmptyInventorySlot();
        if (inventorySlots == -1)
        {
            Debug.Log("Inventory Full");
        }
        else
        {
            inventoryManager.AddItem(id);
            Destroy(this.gameObject);
        }
        
        // TODO: Add the item to the inventory. Make sure to destroy the prefab once the item is collected 
    }
    
}
