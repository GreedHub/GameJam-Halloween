using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;
using ScriptableVariables;

public class CameraTarget : MonoBehaviour
{
  //  [SerializeField] CameraTargetObject hitObject;
    [SerializeField] float PickMaxDistance = 2f; 
    [SerializeField] float PickRadius;
    [SerializeField] ItemInventory inventory;
    [SerializeField] UI_CrosshairText crosshairText;
    [SerializeField] GameStatus gameStatus;
    [SerializeField] IntReference burnedItems;

    // Start is called before the first frame update
    void Start()
    {
        foreach(InventorySlot itemSlot in inventory.slots){
            itemSlot.item = null; 
        }
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
 
        float distanceToObstacle = 0;

        if (Physics.SphereCast(transform.position, .1f, transform.forward, out hit, PickMaxDistance))
        {
            distanceToObstacle = hit.distance;

            Debug.DrawRay(transform.position, transform.forward*PickMaxDistance, Color.green);
            InteractWith(hit.transform.gameObject);
        }

        

    }

    void InteractWith(GameObject hitObject){

       crosshairText.text = "";
       string tag = hitObject.tag;

       switch(tag){

            case "Item":

                EnablePick(hitObject);
                crosshairText.text = "Pickup (E)";

                if(Input.GetButtonDown("Use")){
                    Debug.Log(hitObject.GetComponent<ItemLogic>().itemData.name);
                    GetItem(hitObject);
                }

                break;

            case "Door":
                DoorMechanism dm = hitObject.GetComponent<DoorMechanism>();
                crosshairText.text = dm.isOpen ? "Close (E)" : "Open (E)";
               
                if(Input.GetButtonDown("Use"))
                    dm.Use();
                break;

            case "ExitDoor":
                
                crosshairText.text = gameStatus.isExitDoorLocked ? "Locked" : "Exit (E)";
               
                if(Input.GetButtonDown("Use") &&  !gameStatus.isExitDoorLocked){
                    gameStatus.hasWon = true;
                    gameStatus.state = GameStates.END;
                }

                break;

            case "LockedDoor":
                
                crosshairText.text = "Locked";

                break;

            case "FirePlace":

                crosshairText.text = "Burn cursed items (E)";
                
                if(Input.GetButtonDown("Use")){
                    int burned = inventory.BurnItems();
                    burnedItems.Value += burned;
                    if(burnedItems.Value >= 10) gameStatus.isExitDoorLocked = false;
                    //ALERT DOOR HAS BEEN OPENED
                }

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
