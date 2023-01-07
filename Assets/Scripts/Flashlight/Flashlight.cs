using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
   [SerializeField] float lightDecay = .1f;
   [SerializeField] float angleDecay = 1f;
   [SerializeField] float minimumAngle = 40f;

   Light myLight;

   public void RestoreLightAngle(float restoreAngle)
   {
    myLight.spotAngle = restoreAngle;
   }
   public void RestoreLightIntensity(float intensityAmount)
   {
    myLight.intensity = myLight.intensity + intensityAmount; 
   }
   private void Start() 
   {
     myLight = GetComponent<Light>();
   }

   private void Update() 
   {
        DecreaseLightAngle();
        DecreaseLightIntensity();
   }

    void DecreaseLightAngle()
    {
        if (myLight.spotAngle <= minimumAngle) { return; }
        myLight.spotAngle = myLight.spotAngle - angleDecay * Time.deltaTime;
        
    }

    void DecreaseLightIntensity()
    {
        myLight.intensity = myLight.intensity - lightDecay * Time.deltaTime;
    }
    
}
