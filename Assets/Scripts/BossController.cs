using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    private PlayerMovement playerScript;

    private NavMeshAgent agent;
    private Animator animator;
    private Rigidbody rigidbody;
    private GameObject target;
    private float mesafa;

    EnemyManager enemyManager;
    //EnemyManager enemyManager;

    private void Awake()
    {
        enemyManager = GetComponent<EnemyManager>();
        target = GameObject.Find("Hero");

        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        
        //  target = GameObject.Find("Player");
    }


    private void Update()
    {
        
        if (!enemyManager.dead)
        {
            agent.destination = target.transform.position;
        }
        mesafa = Vector3.Distance(this.transform.position, target.transform.position);

        if (mesafa < 5 && !enemyManager.dead)
        {
            animator.SetBool("Attack2", true);

        }
        else if (mesafa > 5 && !enemyManager.dead)
        {

            animator.Play("runanim");
            animator.SetBool("Attack2", false);
        }

    }

}
