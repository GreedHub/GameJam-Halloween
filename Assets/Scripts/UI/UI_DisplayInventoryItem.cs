using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Items;
public class UI_DisplayInventoryItem : MonoBehaviour
{

    [SerializeField] InventorySlot slot;
    [SerializeField] RawImage sprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){

        Debug.Log(slot.isEmpty);

        if(slot.isEmpty){ 
            sprite.color = new Color(1,1,1,0);
            sprite.texture = null;
            return;
        };

        if(sprite.texture != null) return;
        
        sprite.color = new Color(1,1,1,1);
        sprite.texture = slot.item.icon;

    }
}
