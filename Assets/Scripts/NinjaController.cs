using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class NinjaController : MonoBehaviour
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
            animator.SetBool("Attack2", true);

        }
        else if (mesafa > 5 && !enemyManager.dead)
        {

            animator.Play("runanim");
            animator.SetBool("Attack2", false);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Destroy(this.gameObject);
            Debug.Log("HASAR AL");
            //   collision.gameObject.transform.GetChild(0).GetComponent<Camera>().
        }
    }


}
