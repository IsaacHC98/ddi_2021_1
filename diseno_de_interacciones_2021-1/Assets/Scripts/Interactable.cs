using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool isInsideZone = false;
    public bool gazedAt = false;
    public float gazeInteractTime = 2f;
    public float gazeTimer = 0;
    //public KeyCode interactionKey = KeyCode.E;
    public string interactionButton = "Interact";

    public virtual void Update() {
        //if(isInsideZone && Input.GetKeyDown(interactionKey)){
        if(isInsideZone && CrossPlatformInputManager.GetButtonDown(interactionButton)){
            Interact();
        }
        if(gazedAt){
            ;
            if((gazeTimer += Time.deltaTime) >= gazeInteractTime){
                Interact();
                gazedAt = false;
                gazeTimer = 0;
            }
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
   public void SetGazedAt(bool gazedAt){
       this.gazedAt = gazedAt;
       if(!gazedAt){
           gazeTimer = 0;
       }
   }

   public virtual void OnTriggerExit(Collider other) {
       if(!other.CompareTag("Player")){
           return;
       }
       Debug.Log("Salio del area");
       isInsideZone = false;
   }

   private void OnMouseDown() {
       Interact();
   }

    public virtual void Interact(){

    }
}
