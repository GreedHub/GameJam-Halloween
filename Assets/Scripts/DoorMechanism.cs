using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMechanism : MonoBehaviour
{

    [SerializeField] Quaternion targetRotation;
    private float timeCount = 0.0f;
    public bool isOpen{
        get{ return targetRotation.z ==  90; }
    }
    // Start is called before the first frame update
    void Start()
    {
        targetRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(targetRotation.z != transform.rotation.z){
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, timeCount);
            timeCount = timeCount + Time.deltaTime;
        }
    }

    public void Use(){
        ToggleTargetRotation();
    }

    void ToggleTargetRotation(){
        switch(targetRotation.z){
            case 90:
                targetRotation.z = 0;
                break;
            case  0:
                targetRotation.z =  90;
                break;
            default:
                targetRotation.z = 0;
                break;
        }
    }
}
