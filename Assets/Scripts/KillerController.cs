using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class KillerController : MonoBehaviour
{
    private PlayerMovement playerScript;

    private NavMeshAgent agent;
    private Animator animator;
    private Rigidbody rigidbody;
    private GameObject target;
    private float mesafa;

    EnemyManager enemyManager;


    private void Awake()
    {
        target = GameObject.Find("Hero");

        enemyManager = GetComponent<EnemyManager>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
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
            animator.SetBool("Attack", true);

        }
        else if (mesafa > 5 && !enemyManager.dead)
        {
            animator.SetBool("Attack", false);
        }

    }

}
