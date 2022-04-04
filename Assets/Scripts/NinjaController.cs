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
    private GameObject Exit;
    private float mesafa;


    EnemyManager enemyManager;

     public ScoreHealt scoreHealt;

    private void Awake()
    {
        target = GameObject.Find("Mine");
        Exit = GameObject.Find("ExitPoint");
        enemyManager = GetComponent<EnemyManager>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        scoreHealt = GameObject.Find("GameManager").GetComponent<ScoreHealt>();
        //  target = GameObject.Find("Player");
    }

    private void Start()
    {
        ScoreHealt.Gold = target.transform.childCount;

        agent.destination = target.transform.GetChild(0).position;


    }

    private void Update()
    {
        if (enemyManager.dead)
        {
            agent.isStopped=true;
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
        }
        
        //if (!enemyManager.dead)
        //{
        //    agent.destination = target.transform.position;
        //}
        //  mesafa = Vector3.Distance(this.transform.position, target.transform.position);


        /*

        if (mesafa < 5 && !enemyManager.dead)
        {
            animator.SetBool("Attack2", true);

        }
        else if (mesafa > 5 && !enemyManager.dead)
        {

            animator.Play("runanim");
            animator.SetBool("Attack2", false);
        }
         */
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gold"))
        {
            Destroy(other.gameObject);
            //burada o objeyi yok ediyor altta tekrar atýyoruz
            agent.destination = Exit.transform.position;

            scoreHealt.GotGold();

            transform.GetChild(2).gameObject.SetActive(true);
            
        }


        if (other.gameObject.CompareTag("Exit"))
        {
            if (target.transform.childCount > 0)
            {
                agent.destination = target.transform.GetChild(0).position;
                transform.GetChild(2).gameObject.SetActive(false);

                scoreHealt.LeaveGold();
                ScoreHealt.Gold--;
            }
            else
            {
                Debug.Log("Oyun bitti");
                Time.timeScale = 0;
            }
        }



    }

}
