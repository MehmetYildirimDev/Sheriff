using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    private void Start()
    {
        Instantiate(enemy, this.gameObject.transform.position, Quaternion.identity);
    }


}
