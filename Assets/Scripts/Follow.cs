using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follow : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private GameObject go;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agent.destination = go.transform.position;

        if (gameObject.transform.position==go.transform.position)
        {
            Debug.Log("ayný konum");
        }
    }

}
