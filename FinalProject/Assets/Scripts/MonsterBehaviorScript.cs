using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterBehaviorScript : MonoBehaviour
{
    public Transform player; 
    public float detectionRange = 10f; 
    public float moveSpeed = 3f; 
    public float boostedSpeed = 5f; 
    public float rotationSpeed = 5f;
    public float stoppingDistance = 1.5f; 
    public float MonsterHP = 1000; 

    private bool isPaused = false; 
    private float distanceToPlayer;

   
    void Update()
    {

        
        distanceToPlayer = Vector3.Distance(transform.position, player.position);

        
        if (MonsterHP <= 500)
        {
            moveSpeed = boostedSpeed;
            
        }

       
        if (distanceToPlayer <= detectionRange && !isPaused)
        {
            ChasePlayer();
        }
    }

    void ChasePlayer()
    {
       
        Vector3 direction = (player.position - transform.position).normalized;

       
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        
        if (distanceToPlayer > stoppingDistance)
        {
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    public void TakeDamage(float amount)
    {
        MonsterHP -= amount;
        if (MonsterHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy has died!");
        Destroy(gameObject);
        GetComponent<WorldManager>().DeadEnemies += 1;
    }
}


