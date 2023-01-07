using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour

{
    [SerializeField] [Range(0,60)] int zoomedin;   
    [SerializeField] [Range(60,180)] int zoomedout;
    [SerializeField] [Range(0,2)] float SensitivityZoomedin;
    [SerializeField] [Range(0,10)] float SensitivityZoomedout;
    Camera _camera;
    RigidbodyFirstPersonController fpsController;
    
    void Start() 
    {
        
        _camera = GetComponentInParent<Camera>();
        fpsController = GetComponentInParent<RigidbodyFirstPersonController>();
            
    }
    void Update()
    {
        Zoom();
    }

    private void Zoom()
    {
        if (Input.GetButton("Fire2"))
        {
            _camera.fieldOfView = zoomedin;
            fpsController.mouseLook.XSensitivity = fpsController.mouseLook.YSensitivity = SensitivityZoomedin;
        }
        else
        {
            _camera.fieldOfView = zoomedout;
            fpsController.mouseLook.XSensitivity = fpsController.mouseLook.YSensitivity = SensitivityZoomedout;
        }
    }
}
