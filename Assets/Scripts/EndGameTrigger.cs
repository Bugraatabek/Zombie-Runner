using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameTrigger : MonoBehaviour
{
    [SerializeField] Canvas victoryCanvas;
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            victoryCanvas.enabled = true;
            Time.timeScale = 0;
            FindObjectOfType<WeaponSwitcher>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
