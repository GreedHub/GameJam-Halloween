using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AI{
    public class AI_FollowPlayer : MonoBehaviour
    {       
        NavMeshAgent agent;  
        [SerializeField] bool isAttacking = false;
        [SerializeField] GameObject player;
        [SerializeField] float walkRadius = 10f;
        [SerializeField] bool isActive;
        //GameObject[] childrens;
        // Start is called before the first frame update
        void Start()
        {
            isActive = true;
            agent = gameObject.GetComponent<NavMeshAgent>();

        }


        void ActivateGraphics(){
            isActive = true;
            for(int i = 0; i <= transform.childCount; i++){
                Transform ct = transform.GetChild(i);
                ct.gameObject.SetActive(true);
            }            
        }

        void DeactivateGraphics(){
            isActive = false;
            for(int i = 0; i <= transform.childCount; i++){
                Transform ct = transform.GetChild(i);
                ct.gameObject.SetActive(false);
            }            
        }

        void WalkToRandomPosition(){

            if(agent.remainingDistance > .1f) return;

            Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1);
            Vector3 finalPosition = hit.position;
            agent.SetDestination(finalPosition);

        }

        // Update is called once per frame
        void Update()
        {
            if(isAttacking){    

                agent.speed = 2f;          
                
                if(!isActive) ActivateGraphics();

                agent.SetDestination(player.transform.position);
                
            }else{

                agent.speed = .5f;

                if(isActive) DeactivateGraphics();

                WalkToRandomPosition();
                
            }
        }
    }
}
