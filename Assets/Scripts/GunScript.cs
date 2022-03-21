using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;

    public Camera FpsCamera;

    public ParticleSystem muzzleFLash;

    public GameObject impactEffect;
    public float impactForce=30f;

    private float nextTimetoFire = 0f;
    void Update()
    {

        if (Input.GetButton("Fire1") && Time.time >=nextTimetoFire)
        {
            nextTimetoFire = Time.time + 1f / fireRate;
            Shoot();
        }

    }

    void Shoot()
    {
        muzzleFLash.Play();
        RaycastHit hit;
        
        if (Physics.Raycast(FpsCamera.transform.position, FpsCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            
           Follow Target = hit.transform.GetComponent<Follow>();

            if (Target != null)
            {
                Target.DamageTake(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal*impactForce);
            }

            GameObject impactGO= Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 1f);
        }
    }
}
