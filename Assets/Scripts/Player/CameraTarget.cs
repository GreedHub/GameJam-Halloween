using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;


public class CameraTarget : MonoBehaviour
{
  //  [SerializeField] CameraTargetObject hitObject;
    [SerializeField] float PickMaxDistance = 2f; 
    [SerializeField] float PickRadius;
    [SerializeField] ItemInventory inventory;

    // Start is called before the first frame update
    void Start()
    {
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


       string tag = hitObject.tag;

       switch(tag){

            case "Item":

                EnablePick(hitObject);

                if(Input.GetButton("Use")){
                    Debug.Log(hitObject.GetComponent<ItemLogic>().itemData.name);
                    GetItem(hitObject);
                }

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