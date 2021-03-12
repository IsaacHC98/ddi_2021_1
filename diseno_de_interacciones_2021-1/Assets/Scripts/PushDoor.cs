using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushDoor : Interactable
{
    private Rigidbody rb;
    public Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void Interact()
    {
        rb.useGravity = true;
        rb.isKinematic = false;
        rb.AddForce(direction * 10, ForceMode.Force);

    }
}
