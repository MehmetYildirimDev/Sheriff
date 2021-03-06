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
        
    }


    private void Update()
    {
        
        if (!enemyManager.dead)
        {
            agent.destination = target.transform.position;
        }
        mesafa = Vector3.Distance(this.transform.position, target.transform.position);

        if (mesafa < 3 && !enemyManager.dead)
        {
            animator.SetBool("attack", true);
        }
        else if (mesafa > 3 && !enemyManager.dead)
        {        
            animator.SetBool("attack", false);
        }

    }

}
