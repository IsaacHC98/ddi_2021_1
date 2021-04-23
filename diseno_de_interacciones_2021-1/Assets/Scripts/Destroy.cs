using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : Interactable
{
    public GameObject go;
    
    public override void Interact()
    {
        Destroy(go);
    }
}
