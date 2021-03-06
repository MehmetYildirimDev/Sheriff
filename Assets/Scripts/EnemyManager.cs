using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{

    public float Healt = 50f;

    public bool dead = false;

    private Animator animator;
    private Rigidbody rigidbody;

    ScoreHealt scoreHealt;

 


    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        scoreHealt = GameObject.Find("GameManager").GetComponent<ScoreHealt>();

    }

    public void DamageTake(float amount)
    {
        if (this.gameObject.CompareTag("Boss"))
        {
            Healt -= amount / 2;
            if (Healt <= 0f)
            {
                Die();
            }
        }

        if (this.gameObject.CompareTag("Killer"))
        {
            Healt -= amount;
            if (Healt <= 0f)
            {
                Die();
            }
        }

        if (this.gameObject.CompareTag("Ninja"))
        {
            Healt -= amount;
            if (Healt <= 0f)
            {
                Die();
            }
        }

    }

    public void Die()
    {
        dead = true;
        ScoreHealt.Score++;
        scoreHealt.ScorePlus();

        animator.Play("Daed");
        this.gameObject.isStatic = true;
        this.gameObject.GetComponent<Collider>().enabled = false;
        rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        Destroy(this.gameObject, 6f);
    }


}
