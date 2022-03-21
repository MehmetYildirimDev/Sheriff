using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

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

        if (mesafa < 5)
        {
            animator.SetBool("Attack1", true);

        }
        else
        {

            animator.Play("runanim");
            animator.SetBool("Attack1", false);
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
