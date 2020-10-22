using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Damage : MonoBehaviour
{
    Renderer ai_renderer;
    Camera mainCamera;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
      ai_renderer = GetComponent<Renderer>(); 
      agent = transform.parent.gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update(){

        if(ai_renderer.isVisible && InPositionToAttack()){
            Debug.Log("TE VEO... DAME UN ABRAZO...");
        }
    }

    bool InCameraRange(){
        Vector3 viewportPoint = mainCamera.WorldToViewportPoint(transform.position);

        return viewportPoint.x >= 0 &&
               viewportPoint.x <= 1 &&
               viewportPoint.y >= 0 &&
               viewportPoint.y <= 1 &&
               viewportPoint.z >= 0;
    }

    bool InPositionToAttack(){
        return InCameraRange() || CloseToPlayer();
    }

    bool CloseToPlayer(){
        return agent.remainingDistance <= agent.stoppingDistance + .2f;
    }
}
