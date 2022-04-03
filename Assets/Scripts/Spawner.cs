using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy;
    public float SpawnTime = 0f, SpawnAgain = 15f;

    private void Start()
    {
        InvokeRepeating("Spawn", SpawnTime, SpawnAgain);
    }

    public void Spawn()
    {
        int rand = (int)Random.Range(0, 3);

        if (rand == 0)
        {
            SpawnTime = 30f;
        }
        if (rand == 1)
        {
            SpawnTime = 15f;
        }
        if (rand == 2)
        {
            SpawnTime = 10f;
        }

        Instantiate(enemy[rand], this.transform.position, Quaternion.identity);

    }

}