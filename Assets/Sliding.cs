using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliding : Interactable
{
    public InventoryManager inventoryManager;

    public override void Interact()
    {
        if (inventoryManager.WithKey())
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime, transform.position.z);
            id = "Sliding Door";
        }
        else id = "Locked Door";
    }
}
