using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follow : MonoBehaviour
{
    private NavMeshAgent agent;


    [SerializeField] private GameObject Mine;
    [SerializeField] private GameObject hero;
    [SerializeField] private GameObject runner;
    [SerializeField] private GameObject goldstatic;
    private GameObject emtyp;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

    }
    private void Start()
    {
        emtyp = Mine.transform.GetChild(0).gameObject;
    }

    private void Update()
    {
            agent.destination = emtyp.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gold"))
        {
            emtyp = runner;
            Destroy(other.gameObject, 1f);
        }
        if (other.gameObject.CompareTag("runner"))
        {
            goldstatic.gameObject.transform.localScale = 1.2f * goldstatic.gameObject.transform.localScale;


            if (Mine.transform.childCount>0)
            {
                emtyp = Mine.transform.GetChild(0).gameObject;
            }
            else
            {
                Debug.Log("Gold kalmadý");
                Time.timeScale = 0;
            }
            
        }
    }
}
