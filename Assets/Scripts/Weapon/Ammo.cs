using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;
    
    
    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    public void AddAmmo(AmmoType ammoType, int ammoCount)
    {
        GetAmmoSlot(ammoType).ammoAmount = GetAmmoSlot(ammoType).ammoAmount + ammoCount;
    }
    public void ReduceAmmo(AmmoType ammoType)
    {  
        GetAmmoSlot(ammoType).ammoAmount--;   
    }
    public int GetAmmoCount(AmmoType ammoType)
    {
        
        return GetAmmoSlot(ammoType).ammoAmount;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach(AmmoSlot slot in ammoSlots)
        {
            if(slot.ammoType == ammoType)
            {
                return slot;
            }
        }
            return null;
    }


}
