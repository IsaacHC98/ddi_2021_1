using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool isInsideZone = false;
    public KeyCode interactionKey = KeyCode.E;

    public virtual void Update() {
        if(isInsideZone && Input.GetKeyDown(interactionKey)){
            Interact();
        }
    }

   public virtual void OnTriggerEnter(Collider other)
   {
       if(!other.CompareTag("Player")){
           return;
       }
       Debug.Log("Entro en el area");
       isInsideZone = true;
   }

   public virtual void OnTriggerExit(Collider other) {
       if(!other.CompareTag("Player")){
           return;
       }
       Debug.Log("Salio del area");
       isInsideZone = false;
   }

    public virtual void Interact(){

    }
}
