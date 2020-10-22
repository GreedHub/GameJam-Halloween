using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraTarget : MonoBehaviour
{
    [SerializeField] CameraTargetObject hitObject;
    [SerializeField] float PickMaxDistance = 2f; 
    [SerializeField] float PickRadius;

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
            hitObject.targetObject = hit.transform.gameObject;
            Debug.DrawRay(transform.position, transform.forward*PickMaxDistance, Color.green);
        }

    }


}
