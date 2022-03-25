using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public GunScript gunScript;
    

    private void Start()
    {

        

    }

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("burada");
            gunScript.Totalbullet += 30;

            if (ScoreHealt.Healt<100)
            {
                ScoreHealt.Healt += 20;
                Mathf.Clamp(ScoreHealt.Healt, 0, 100);
            }

            gunScript.TotalAmmo.text = gunScript.Totalbullet.ToString();
            Destroy(this.gameObject);

            
        }
    }
}
