using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPSCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float timeBetweenShots = 0.5f;
    [SerializeField] TextMeshProUGUI ammotext;
    bool canShoot = true;
    
    private void OnEnable()
    {
        canShoot = true; 
    }
    void Update()
    {
        DisplayAmmo();
        if(Input.GetButtonDown("Fire1") && canShoot == true)
        {
           StartCoroutine(Shoot());
        }
    }
    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetAmmoCount(ammoType);
        ammotext.text = "Ammo:" +  currentAmmo.ToString();
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if(ammoSlot.GetAmmoCount(ammoType) > 0)
        {
            ammoSlot.ReduceAmmo(ammoType);
            ProcessRaycast();
            ProcessMuzzleFlash();
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) { return; }
            target.TakeDamage(damage);
            

        }
        else { return; }
    }
    private void ProcessMuzzleFlash()
    {
        muzzleFlash.Play();
    }
    private void CreateHitImpact(RaycastHit hit)
    {
       GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
       Destroy(impact, 1);
    }
}
