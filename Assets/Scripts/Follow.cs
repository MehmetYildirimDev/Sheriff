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

    public float Healt = 50f;

    public bool dead;

    

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
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
            animator.SetBool("Attack1", true);

        }
        else if (mesafa>5 && !dead)
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

    public void DamageTake(float amount)
    {
        Healt -= amount;
        if (Healt<=0f)
        {
            
            dead = true;
            animator.Play("Daed");
            Die();
        }
    }

    public void Die()
    {
        Destroy(this.gameObject, 10f);
    }
}
