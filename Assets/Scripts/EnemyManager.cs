using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float Healt = 50f;

    public bool dead=false;

    private Animator animator;
    private Rigidbody rigidbody;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
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
        this.gameObject.GetComponent<Collider>().enabled = false;
        rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        Destroy(this.gameObject, 10f);
    }
}
