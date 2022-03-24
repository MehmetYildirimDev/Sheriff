using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{

    NinjaController NinjaController;
    KillerController KillerController;
    BossController BossController;


    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;

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
    public float ReloadTime = 2;
    public Text clip;
    public Text TotalAmmo;
    private bool canShoot = true;


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
        if (Totalbullet < 0)
        {
            canShoot = false;
        }

        clip.text = clipbullet + "/";

        if (Input.GetButton("Fire1") && Time.time >= nextTimetoFire && canShoot)
        {


            nextTimetoFire = Time.time + 1f / fireRate;
            if (clipbullet > 0)
            {
                Shoot();
            }
            else
            {
                ReloadClip();
            }

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadClip();
        }

    }

    void Shoot()
    {
        //        Totalbullet -= 1;
        clipbullet -= 1;


        muzzleFlash.Play();

        audioSource.PlayOneShot(audios[0]);

        RaycastHit hit;

        if (Physics.Raycast(FpsCamera.transform.position, FpsCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            //BUG

            //            Damage Target = hit.transform.GetComponent<Damage>();


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

    void ReloadClip()
    {
        //25 mermi var ve totalde 10 mermi kaaldý 
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
    }



}
