using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool isInsideZone = false;
    //public KeyCode interactionKey = KeyCode.E;
    public string interactionButton = "Interact";

    public virtual void Update() {
        //if(isInsideZone && Input.GetKeyDown(interactionKey)){
        if(isInsideZone && CrossPlatformInputManager.GetButtonDown(interactionButton)){
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
