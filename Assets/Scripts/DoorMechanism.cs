using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMechanism : MonoBehaviour
{


    Vector3 targetRotation;
    private float timeCount = 0.0f;
    public bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        targetRotation = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        
/*         if(targetRotation.z != transform.rotation.z){
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, timeCount);
            timeCount = timeCount + Time.deltaTime;
        }  */
    }

    public void Use(){
        
        if(isOpen){
            targetRotation.y -= 90;            
        }else{
            Debug.Log("entre aca");
            targetRotation.y += 90;
        }

        isOpen = !isOpen;

        transform.eulerAngles = targetRotation;
    }

}