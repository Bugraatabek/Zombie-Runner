using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour

{
    
    [SerializeField] int ammoCount;
    [SerializeField] AmmoType ammoType;
    Ammo _ammo;
    void Start()
    {
        _ammo = FindObjectOfType<Ammo>();
    }
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Player")
        {
            _ammo.AddAmmo(ammoType, 10);
            Debug.Log("You've picked up ammo");
            Destroy(gameObject);
        }
    }
}
