using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType{
    Equip, Weapon, Medicine, MonsterCard
}

[CreateAssetMenu(fileName= "New Item", menuName="InventoryAR/Generic")]

public class ItemAR : ScriptableObject
{
    public ItemType itemType = ItemType.Equip;
    public Sprite icon = null;

    public virtual void Use(){
        Debug.Log($"Usando item {name}");
    }
}
