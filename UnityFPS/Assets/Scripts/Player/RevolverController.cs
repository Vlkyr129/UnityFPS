using System.Collections;
using UnityEngine;
using DG.Tweening;

public class RevolverController : MonoBehaviour
{
    public Camera fpsCam;
    public GameObject impactEffect;
    public GameObject barrelEffect;
    public GameObject ReloadEffect;

    [Header("Gun Characteristics")]
    [SerializeField]
    float damage = 10f;
    [SerializeField]
    int maxAmmo = 7;
    [SerializeField]
    int currentAmmo;
    [SerializeField]
    float releodTime = 5f;

    private void Start()
    {
        currentAmmo = maxAmmo;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            currentAmmo = maxAmmo;
        }

        if (Input.GetButtonDown("Fire1") && currentAmmo != 0)
        {
            Shoot();
        }

        if (Input.GetButtonDown("Fire1") && currentAmmo == 0)
        {
            NeedReloadPrompt();
        }
    }

    void Reload()
    {
        currentAmmo = maxAmmo;
    }

    public void Shoot()
    {
        currentAmmo--;

        //Add tweening punch effect to barrel
        barrelEffect.transform.DORewind();
        barrelEffect.transform.DOPunchScale(new UnityEngine.Vector3(1, 0, .5f), .25f);

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

    void NeedReloadPrompt()
    {
        ReloadEffect.transform.DORewind();
        ReloadEffect.transform.DOPunchScale(new UnityEngine.Vector3(.5f, 0, .25f), .25f);
    }
     
}
