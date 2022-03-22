using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy;
    public float SpawnTime = 0f, SpawnAgain = 5f;

    private void Start()
    {
        InvokeRepeating("Spawn", SpawnTime, SpawnAgain);
    }

    public void Spawn()
    {
        Instantiate(enemy[(int)Random.Range(0, 3)], this.transform.position, Quaternion.identity);
    }

}


/*

public void Spawn()
{



    if (BirdScript.isdead)
    {
        CancelInvoke("Spawn");
    }

}
 */