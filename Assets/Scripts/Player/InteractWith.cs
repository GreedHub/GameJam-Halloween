using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWith : MonoBehaviour
{
    CharacterController charCtrl;
    // Start is called before the first frame update
    void Start()
    {
        charCtrl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        Vector3 p1 = transform.position + charCtrl.center;
        float distanceToObstacle = 0;
        
        if (Physics.SphereCast(p1, charCtrl.height / 2, transform.forward, out hit, 10))
        {
            distanceToObstacle = hit.distance;
        }

    }
}
