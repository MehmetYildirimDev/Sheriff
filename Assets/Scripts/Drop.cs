using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public GunScript gunScript;

    AudioSource audioSource;
    public AudioClip HealSound;

    Animator animator;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();

    }

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(HealSound);
            animator.Play("DestroyAnim");
         

            gunScript.Totalbullet += 30;

            if (ScoreHealt.Healt<100)
            {
                ScoreHealt.Healt += 20;
                Mathf.Clamp(ScoreHealt.Healt, 0, 100);
            }

            gunScript.TotalAmmo.text = gunScript.Totalbullet.ToString();
            Destroy(this.gameObject,2f);

            
        }
    }
}
