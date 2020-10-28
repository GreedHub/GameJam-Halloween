using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using ScriptableVariables;

public class AI_Damage : MonoBehaviour
{
    [SerializeField] IntReference spiritPressure;
    [SerializeField] float hitRange;
    [SerializeField] AI_Data aiData;
    Renderer ai_renderer;
    Camera mainCamera;
    NavMeshAgent agent;
     float elapsed = 0f;
    [SerializeField] GameObject screamSound;
     float screamTime;
    // Start is called before the first frame update
    void Start()
    {
      mainCamera = Camera.main;
      ai_renderer = GetComponent<Renderer>(); 
      agent = transform.parent.transform.parent.gameObject.GetComponent<NavMeshAgent>();
      aiData.hasAlreadyScreamed = false;
    }

    // Update is called once per frame
    void Update(){
            
        if(InPositionToAttack() && aiData.isAttacking){
            if(!aiData.hasAlreadyScreamed){
                 aiData.hasAlreadyScreamed = true;
                 screamSound.SetActive(true);
                 screamTime = Time.deltaTime;
            }else{
                if(screamTime >= 4.1f) screamSound.SetActive(false);
            }
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
