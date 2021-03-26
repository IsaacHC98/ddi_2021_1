using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "New MonsterCard", menuName="InventoryAR/MonsterCards")]
public class MonsterCard : ItemAR
{
    public int atkPoints = 1000;
    public int defPoints = 1000;

    public override void Use(){
        base.Use();
        Debug.Log("Monstruo invocado");
    }
}