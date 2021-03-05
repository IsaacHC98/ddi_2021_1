using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : Interactable
{
    public Vector3 direction;
    public GameObject platform;

    enum EleStates{goUp, goDown, Pause};
    EleStates states;
    public Transform top;
    public Transform bottom;
    public float smooth;
    Vector3 newPos;
    bool hasRider;

    // Start is called before the first frame update
    void Start()
    {
        states = EleStates.Pause;
    }

    // Update is called once per frame
    public override void Update()
    {
        if(platform.transform.position.y < 3 && isInsideZone && Input.GetKeyDown(interactionKey)){
            states = EleStates.goUp;
        }

        if(platform.transform.position.y > 3 && isInsideZone && Input.GetKeyDown(interactionKey)){
            states = EleStates.goDown;
        }

        FMS();
    }


    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if(other.tag == "Player"){
            other.transform.parent = gameObject.transform;
        }
    }

    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        if(other.tag == "Player"){
            other.transform.parent = null;
        }
    }

    void FMS(){
        if(states == EleStates.goDown){
            newPos = bottom.position;
            transform.position = Vector3.Lerp(transform.position, newPos, smooth * Time.deltaTime);
        }

        if(states == EleStates.goUp){
            newPos = top.position;
            transform.position = Vector3.Lerp(transform.position, newPos, smooth * Time.deltaTime);
        }

        if(states == EleStates.Pause){
        }
    }
}
