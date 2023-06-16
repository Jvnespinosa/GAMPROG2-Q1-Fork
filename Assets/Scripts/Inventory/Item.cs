using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactable
{
    public abstract class Interactable : MonoBehaviour
    {
        public string id;
        public abstract void Interact();
    }
    public override void Interact()
    {
        Destroy(this.gameObject);
        
        // TODO: Add the item to the inventory. Make sure to destroy the prefab once the item is collected 
    }
    
}
