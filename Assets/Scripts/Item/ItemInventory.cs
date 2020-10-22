using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items{    

    [CreateAssetMenu(fileName = "ItemInventory", menuName="Items/Inventory")]
    class ItemInventory: ScriptableObject{
    
        public InventorySlot[] slots = new InventorySlot[10];
        public int maxCapacity = 10;
        public bool isEmpty {
            get{
                foreach (var slot in slots){
                    if(!slot.isEmpty) return false;
                }
                return true;
            }
        }
        public bool isFull {
            get{
                foreach (var slot in slots){
                    if(slot.isEmpty) return false;
                }
                return true;
            }
        }

        public void AddItem(Item item){

            foreach (var slot in slots){

                if(!slot.isEmpty) continue;
                
                slot.item = item;
                
            }

        }
        
    }
}