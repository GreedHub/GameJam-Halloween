using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items{    
    [CreateAssetMenu(fileName = "New InventorySlot", menuName="Inventory/Slot")]
    public class InventorySlot: ScriptableObject{    
        public int id;
        public Item item;

        public bool isEmpty{
            get{ return item == null; }
        }
    }
}