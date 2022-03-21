using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Camera FpsCamera;

    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(FpsCamera.transform.position, FpsCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            
           Follow Target = hit.transform.GetComponent<Follow>();

            if (Target != null)
            {
                Target.DamageTake(damage);
            }
        }
    }
}
