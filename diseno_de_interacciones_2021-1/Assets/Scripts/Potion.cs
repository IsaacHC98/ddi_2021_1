using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "New Potion", menuName="InventoryAR/Medicine")]
public class Potion : ItemAR
{
    public float lifeAmount = 5.0f;
    public float effectiveness = 10f;

    public override void Use(){
        base.Use();
        Debug.Log($"Aumentando la vida en {lifeAmount} unidades");
    }
}
