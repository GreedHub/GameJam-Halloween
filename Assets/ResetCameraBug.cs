using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCameraBug : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CameraTarget ct = gameObject.GetComponent<CameraTarget>();
        ct.enabled = false;
        ct.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
