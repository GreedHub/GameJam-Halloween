using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items{    

    [CreateAssetMenu(fileName = "ItemInventory", menuName="Items/Inventory")]
    class ItemInventory: ScriptableObject{
    
        public List<Item> items  = new List<Item>();
        public int maxCapacity = 10;
        public bool isEmpty {
            get{
                return items.Count <= 0;
            }
        }
        public bool isFull {
            get{
                return items.Count >= maxCapacity;
            }
        }

        public void AddItem(Item item){
           
            items.Add(Instantiate(item));

        }
        
    }
}