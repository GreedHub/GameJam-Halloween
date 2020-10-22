using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

public class InteractWith : MonoBehaviour
{
   [SerializeField] CameraTargetObject hitObject;
   [SerializeField] ItemInventory inventory;

    void Update(){
       if(!hitObject.isTargeting) return;

       string tag = hitObject.targetObject.tag;

       switch(tag){

            case "Item":

                EnablePick(hitObject.targetObject);

                if(Input.GetButton("Use"))
                    GetItem(hitObject.targetObject);

                break;

            case "Door":
                break;

            default:
                break;
       }

    }

    void EnablePick(GameObject item){
        Renderer renderer = item.GetComponent<Renderer>();
        //Enable glow shader
    }

    void GetItem(GameObject item){
        if(inventory.isFull){
            //TODO: trigger error message
            return;
        }

        Item _item = item.GetComponent<ItemLogic>().itemData;

        inventory.AddItem(_item);

        Destroy(item);
    }

}
