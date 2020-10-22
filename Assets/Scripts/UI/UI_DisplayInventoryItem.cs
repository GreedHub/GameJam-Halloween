using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;
public class DisplayItem : MonoBehaviour
{

    [SerializeField] InventorySlot slot;
    [SerializeField] GameObject itemPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){

        if(slot.isEmpty) return;

        GameObject item = Instantiate(itemPrefab,transform);
        ItemLogic il = item.GetComponent<ItemLogic>();

        il.itemData = slot.item;

    }
}
