using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follow : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
   [SerializeField] private GameObject target;
    private float mesafa;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
      //  target = GameObject.Find("Player");
    }

    private void Update()
    {

        agent.destination = target.transform.position;
        mesafa = Vector3.Distance(this.transform.position, target.transform.position);

        if (mesafa<5 )
        {
            animator.SetBool("Attack2", true);
        }
        else
        {
            animator.SetBool("Attack2", false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }


}
