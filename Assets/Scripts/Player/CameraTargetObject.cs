using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraTarget", menuName="Utils/CameraTarget")]
class CameraTargetObject: ScriptableObject{
  
    public GameObject targetObject;
    public bool isTargeting {
        get{
            return targetObject != null;
        }
    }
}