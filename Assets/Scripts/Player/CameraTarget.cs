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
    [SerializeField] IntReference spiritPressure;

    Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        foreach(InventorySlot itemSlot in inventory.slots){
            itemSlot.item = null; 
        }
        mainCamera = Camera.main;

        mainCamera.enabled = false;
        mainCamera.enabled = true;
        
    }



    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //loat zoomDistance = zoomSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        //camera.transform.Translate(ray.direction * zoomDistance, Space.World);


        
        float distanceToObstacle = 0;

        if (Physics.Raycast(ray,out hit,PickMaxDistance))
        {
            distanceToObstacle = hit.distance;


            Debug.DrawRay(ray.origin, ray.direction* PickMaxDistance, Color.green);
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
                    spiritPressure.Value += 20;
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
                    spiritPressure.Value -= 10;
                    if (burnedItems.Value >= 5) gameStatus.isExitDoorLocked = false;
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
