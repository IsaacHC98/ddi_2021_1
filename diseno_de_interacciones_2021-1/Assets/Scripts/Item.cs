using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item {

    public enum ItemType {
        RocketLauncher,
        Needler,
        Sniper,
        Armor,
        Medkit,
        ShotgunAmmo,
        RiffleAmmo,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite(){
        switch (itemType){
            default:
            case ItemType.RocketLauncher:   return ItemAssets.Instance.RocketLauncherSprite;
            case ItemType.Needler:          return ItemAssets.Instance.NeedlerSprite;
            case ItemType.Sniper:           return ItemAssets.Instance.SniperSprite;
            case ItemType.Armor:            return ItemAssets.Instance.ArmorSprite;
            case ItemType.Medkit:           return ItemAssets.Instance.MedikitSprite;
            case ItemType.ShotgunAmmo:      return ItemAssets.Instance.ShotgunAmmoSprite;
            case ItemType.RiffleAmmo:       return ItemAssets.Instance.RiffleAmmoSprite;
        }
    }

    public bool IsStackable(){
        switch(itemType){
            default:
            case ItemType.Armor:
            case ItemType.Medkit:
            case ItemType.RiffleAmmo:
            case ItemType.ShotgunAmmo:
                return true;
            case ItemType.RocketLauncher:
            case ItemType.Sniper:
            case ItemType.Needler:
                return false;
        }
    }

}
