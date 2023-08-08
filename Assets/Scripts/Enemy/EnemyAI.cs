using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    Transform target;
    [SerializeField] float chaseRange = 10f;
    [SerializeField] float turnSpeed = 5f;
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    Animator _animator;
    EnemyHealth enemyHealth;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        enemyHealth = GetComponent<EnemyHealth>();
        target = FindObjectOfType<PlayerHealth>().transform;
    }
    
    void Update()
    {
        if (enemyHealth.IsDead())
        {
            enabled = false; // turns of EnemyAI component
            navMeshAgent.enabled = false;
            return;
        }
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if(isProvoked)
        {
            EngageTarget();
            FaceTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;     
        }
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void EngageTarget()
        {
            if(distanceToTarget >= navMeshAgent.stoppingDistance)
            {
                ChaseTarget();
            }
            if(distanceToTarget <= navMeshAgent.stoppingDistance)
            {
                AttackTarget();
            }
        }
   
    private void ChaseTarget()
        {
            _animator.SetTrigger("movement");
            _animator.SetBool("attack", false);
            navMeshAgent.SetDestination(target.position);
        }
    
    private void AttackTarget()
        {
           _animator.SetBool("attack", true);
        }
    
    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }
    
    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
