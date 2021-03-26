using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : Interactable
{
    public ItemAR item;
    public override void Interact()
    {
        //base.Interact();
        InventarioAR.InventarioARInstance.Add(item);
        Destroy(this.gameObject);
    }
}
