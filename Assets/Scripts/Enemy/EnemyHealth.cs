using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    EnemyAI enemyAI;
    Animator _animator;
    [SerializeField] float hitPoints = 100f;
    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken"); // Broadcasts to all the scripts under the ENEMY to start the OnDamageTaken Method // GetComponent<EnemyAI>().OnDamageTaken(); the second way
        hitPoints = hitPoints - damage;
        if(hitPoints<= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        if(isDead == true) { return; }
        isDead = true;
        _animator.SetTrigger("death");
    }
}
