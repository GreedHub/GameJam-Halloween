using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using ScriptableVariables;

public class AI_Damage : MonoBehaviour
{
    [SerializeField] IntReference spiritPressure;
    [SerializeField] float hitRange;
    Renderer ai_renderer;
    Camera mainCamera;
    NavMeshAgent agent;
     float elapsed = 0f;
    // Start is called before the first frame update
    void Start()
    {
      mainCamera = Camera.main;
      ai_renderer = GetComponent<Renderer>(); 
      agent = transform.parent.transform.parent.gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update(){

        if(InPositionToAttack()){
            elapsed += Time.deltaTime;
            if (elapsed >= 1f) {
                elapsed = elapsed % 1f;
                spiritPressure.Value += 1;
            }
            
        }
    }

    bool InPositionToAttack(){
        return ai_renderer.isVisible || CloseToPlayer();
    }

    bool CloseToPlayer(){
        return agent.remainingDistance <= agent.stoppingDistance + hitRange;
    }
}
