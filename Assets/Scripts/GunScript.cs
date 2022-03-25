using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{

    NinjaController NinjaController;
    KillerController KillerController;
    BossController BossController;


    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 10f;

    public Animator animator;

    public Camera FpsCamera;

    public ParticleSystem muzzleFlash;

    public GameObject impactEffect;
    public float impactForce = 30f;

    private float nextTimetoFire = 0f;

    private AudioSource audioSource;
    public AudioClip[] audios;


    public int Totalbullet = 90;
    public int clipbullet = 30;
    public int M4BULLET = 30;
    public int empty = 0;
    public float ReloadTime = 1.17f;
    public Text clip;
    public Text TotalAmmo;
    private bool isReloding = false;



    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        clip.text = clipbullet.ToString();
        TotalAmmo.text = Totalbullet.ToString();
    }

    void Update()
    {
        if (isReloding)
        {
            return;
        }


        if (Totalbullet < 0)
        {
            canShoot = false;
        }

        if (Input.GetKeyDown(KeyCode.R) || clipbullet < 0 && Totalbullet > 0)//mermi bittiðinde sürekli animasyona girecek
        {
            StartCoroutine(ReloadClip());
            return;
        }


        clip.text = clipbullet + "/";

        if (Input.GetButton("Fire1") && Time.time >= nextTimetoFire)
        {
            nextTimetoFire = Time.time + 1f / fireRate;
            Shoot();
        }



    }

    void Shoot()
    {
        clipbullet -= 1;

        muzzleFlash.Play();

        audioSource.PlayOneShot(audios[0]);

        RaycastHit hit;

        if (Physics.Raycast(FpsCamera.transform.position, FpsCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            EnemyManager enemy = hit.transform.GetComponent<EnemyManager>();
            if (enemy != null)
            {
                enemy.DamageTake(damage);
            }


            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 1f);
        }
    }

    IEnumerator ReloadClip()
    {
        isReloding = true;

        animator.Play("ReloadAnim");

        audioSource.PlayOneShot(audios[1]);


        yield return new WaitForSeconds(ReloadTime);

        if (Totalbullet > 0)
        {
            empty = M4BULLET - clipbullet;

            if (empty > Totalbullet)
            {
                empty = Totalbullet;
            }
            Totalbullet -= empty;
            clipbullet += empty;
        }

        TotalAmmo.text = Totalbullet.ToString();

        isReloding = false;
    }



}
