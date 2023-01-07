using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float intensityAmount = 2f;
    [SerializeField] float restoreAngle = 70;
    Flashlight _flashlight;

    private void Start() 
    {
        _flashlight = FindObjectOfType<Flashlight>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
        _flashlight.RestoreLightAngle(restoreAngle);
        _flashlight.RestoreLightIntensity(intensityAmount);
        Destroy(gameObject);
        }   
    }
}
