using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using ScriptableVariables;

namespace AI{
    public class AI_FollowPlayer : MonoBehaviour
    {       
        NavMeshAgent agent;  
        [SerializeField] IntReference spiritPressure;
        [SerializeField] AI_Data aiData;
        [SerializeField] GameObject player;
        [SerializeField] float walkRadius = 10f;
        [SerializeField] bool isActive;
        [SerializeField] float walkSpeed;
        [SerializeField] float runSpeed;

        [SerializeField] GameStatus gameStatus;

        [SerializeField] float attackTime;
        [SerializeField] float attackCooldown; 
        [SerializeField] GameObject screamSound;
        float elapsed = 0f;
        //GameObject[] childrens;
        // Start is called before the first frame update
        void Start()
        {
            agent = gameObject.GetComponent<NavMeshAgent>();
            attackCooldown = 20f;
            attackTime = 5f;
            
        }


        void ActivateGraphics(){
            isActive = true;
            for(int i = 0; i < transform.childCount; i++){
                Transform ct = transform.GetChild(i);
                ct.gameObject.SetActive(true);
            }            
        }

        void DeactivateGraphics(){
            isActive = false;
            for(int i = 0; i < transform.childCount ; i++){
                Transform ct = transform.GetChild(i);
                ct.gameObject.SetActive(false);
            }            
        }

        void WalkToRandomPosition(){


            if(agent.remainingDistance > agent.stoppingDistance) return;

            Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1);
            Vector3 finalPosition = hit.position;

            agent.SetDestination(finalPosition);

        }

        // Update is called once per frame
        void Update()
        {

            if(gameStatus.state != GameStates.PLAYING) return;

            elapsed += Time.deltaTime;
            if (elapsed >= 1f) {
                elapsed = elapsed % 1f;
                if(!aiData.isAttacking) attackCooldown-= 1;
                if(aiData.isAttacking && IsNearPlayer()) attackTime-=1;
            }

            if(attackCooldown<=0 && !aiData.isAttacking){
                StartAttacking();
            }

            if(attackTime<=0 && aiData.isAttacking){
                StopAttacking();
            }

            if(aiData.isAttacking){    

                agent.speed = runSpeed;          
                
                if(!isActive) ActivateGraphics();

                agent.SetDestination(player.transform.position);
                
            }else{

                agent.speed = walkSpeed;

                if(isActive){
                    DeactivateGraphics();
                }

                WalkToRandomPosition();
                
            }
        }

        void StopAttacking(){
            attackCooldown = 100f - spiritPressure.Value;
            if(attackCooldown<15) attackCooldown = 15;
            aiData.isAttacking = false;
        }

        void StartAttacking(){
            attackTime = 5 + spiritPressure.Value;
            aiData.isAttacking = true;
            aiData.hasAlreadyScreamed = false;
            screamSound.SetActive(false);
        }


        bool IsNearPlayer(){
            return Vector3.Distance(player.transform.position, transform.position) < 6f;
        }

    }
}
