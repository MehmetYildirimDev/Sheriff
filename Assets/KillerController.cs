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

    public float Healt = 50f;

    public bool dead;



    private void Awake()
    {
        target = GameObject.Find("Hero");

        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        //  target = GameObject.Find("Player");
    }

    private void Update()
    {
        if (!dead)
        {
            agent.destination = target.transform.position;
        }
        mesafa = Vector3.Distance(this.transform.position, target.transform.position);

        if (mesafa < 5 && !dead)
        {
            animator.SetBool("Attack2", true);

        }
        else if (mesafa > 5 && !dead)
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

    public void DamageTake(float amount)
    {
        Healt -= amount;
        if (Healt <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {

        dead = true;
        animator.Play("Daed");
        this.gameObject.isStatic = true;
        rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        Destroy(this.gameObject, 10f);
    }
}
