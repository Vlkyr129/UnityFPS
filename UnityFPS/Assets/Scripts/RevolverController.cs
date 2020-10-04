
using UnityEngine;

public class RevolverController : MonoBehaviour
{
    public Camera fpsCam;
    public GameObject impactEffect;

    [SerializeField]
    float damage = 10f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
            EnemyController target = hit.transform.GetComponent<EnemyController>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }



            //Creates effect on surface hit
            GameObject ImpactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(ImpactGO, .05f);
        }
    }
}
