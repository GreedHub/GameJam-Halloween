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
        [SerializeField] bool isAttacking = false;
        [SerializeField] GameObject player;
        [SerializeField] float walkRadius = 10f;
        [SerializeField] bool isActive;
        [SerializeField] float walkSpeed;
        [SerializeField] float runSpeed;

        [SerializeField] GameStatus gameStatus;

        [SerializeField] float attackTime;
        [SerializeField] float attackCooldown; 
        float elapsed = 0f;
        //GameObject[] childrens;
        // Start is called before the first frame update
        void Start()
        {
            isActive = true;
            agent = gameObject.GetComponent<NavMeshAgent>();
            attackCooldown = 10;
            attackTime = 5;
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
                if(!isAttacking) attackCooldown-= 1;
                if(isAttacking && IsNearPlayer()) attackTime-=1;
            }

            if(attackCooldown<=0 && !isAttacking){
                StartAttacking();
            }

            if(attackTime<=0 && isAttacking){
                StopAttacking();
            }

            if(isAttacking){    

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
            isAttacking = false;
        }

        void StartAttacking(){
            attackTime = 5 + spiritPressure.Value;
            isAttacking = true;
        }


        bool IsNearPlayer(){
            return Vector3.Distance(player.transform.position, transform.position) < 6f;
        }

    }
}
